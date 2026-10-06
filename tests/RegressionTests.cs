using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using WindowsFormsApp1;

internal static class RegressionTests
{
    private static int passed;
    private static string root;

    [STAThread]
    private static int Main(string[] args)
    {
        if (args.Length > 0 && args[0] == "worker")
        {
            try { new VeriDeposu(args[1]).BiletleriKaydet("deneme", new[] { Ticket(20) }); return 0; }
            catch (InvalidOperationException) { return 2; }
        }
        root = Path.GetFullPath(args[0]);
        Directory.CreateDirectory(root);
        try
        {
            Run("Persistence, login, password hashing", Authentication);
            Run("Reservations, duplicate seats, dates and trains", Reservations);
            Run("Invalid passenger and journey data", Validation);
            Run("Atomic batches and concurrent processes", Concurrency);
            Run("Corrupt and unwritable storage preserves records", StorageFailures);
            Run("All forms and embedded resources load", Forms);
            Console.WriteLine("PASS: " + passed + " regression groups");
            return 0;
        }
        catch (Exception ex) { Console.Error.WriteLine(ex); return 1; }
    }

    private static void Run(string name, Action test) { test(); passed++; Console.WriteLine("PASS " + name); }
    private static void Check(bool condition, string message) { if (!condition) throw new Exception(message); }
    private static void Reject(Action action)
    {
        try { action(); }
        catch (InvalidOperationException) { return; }
        throw new Exception("Invalid operation was accepted.");
    }
    private static void IoReject(Action action)
    {
        try { action(); }
        catch (IOException) { return; }
        catch (UnauthorizedAccessException) { return; }
        throw new Exception("Invalid storage operation was accepted.");
    }
    private static Bilet Ticket(int seat = 1)
    {
        return new Bilet { Id = Guid.NewGuid().ToString("N"), KullaniciAdi = "deneme", Tren = "İZMİR MAVİ",
            Tarih = DateTime.Today.AddDays(2), KoltukNo = seat, Nereden = "Ankara Gar", Nereye = "Sincan",
            Isim = "Çağrı", Soyisim = "Şen", Telefon = "5551234567", Cinsiyet = "ERKEK", Fiyat = 100 };
    }
    private static VeriDeposu Store { get { return new VeriDeposu(Path.Combine(root, "data.xml")); } }

    private static void Authentication()
    {
        Check(Store.GirisYap("deneme", "wrong") == null, "Unknown user logged in.");
        Reject(() => Store.KayitOl("  ", "12345678"));
        Reject(() => Store.KayitOl("ab", "12345678"));
        Reject(() => Store.KayitOl("deneme", "123"));
        Store.KayitOl(" deneme ", "TestPassword123!");
        Store.KayitOl("ikinci", "TestPassword123!");
        Check(Store.GirisYap(" DENEME ", "TestPassword123!") == "deneme", "Saved user did not log in.");
        Check(Store.GirisYap("deneme", "wrong") == null, "Wrong password accepted.");
        Check(Store.GirisYap("deneme", "") == null, "Empty password accepted.");
        Reject(() => Store.KayitOl("DENEME", "AnotherPassword!"));
        string xml = File.ReadAllText(Path.Combine(root, "data.xml"));
        Check(!xml.Contains("TestPassword123!"), "Plaintext password leaked.");
        var doc = new System.Xml.XmlDocument(); doc.LoadXml(xml);
        var salts = doc.SelectNodes("//Tuz");
        Check(salts.Count == 2 && salts[0].InnerText != salts[1].InnerText, "User salts are not unique.");
    }

    private static void Reservations()
    {
        Store.BiletleriKaydet("deneme", new[] { Ticket() });
        var saved = Store.BiletleriOku();
        Check(saved.Count == 1 && saved[0].Isim == "Çağrı" && saved[0].Fiyat == 100, "Ticket did not persist.");
        Reject(() => Store.BiletleriKaydet("deneme", new[] { Ticket() }));
        var route = Ticket(); route.Nereden = "Manisa"; route.Nereye = "Menemen";
        Reject(() => Store.BiletleriKaydet("deneme", new[] { route }));
        var otherDate = Ticket(); otherDate.Tarih = otherDate.Tarih.AddDays(1);
        var otherTrain = Ticket(); otherTrain.Tren = "EGE EKSPRESİ";
        Store.BiletleriKaydet("deneme", new[] { otherDate, otherTrain });
        Check(Store.BiletleriOku().Count == 3, "Separate train/date blocked.");
        Reject(() => Store.BiletleriKaydet("nobody", new[] { Ticket(2) }));
        Reject(() => Store.BiletleriKaydet("ikinci", new[] { Ticket(2) }));
        Reject(() => Store.BiletleriKaydet("deneme", new Bilet[0]));
    }

    private static void Validation()
    {
        Action<Action<Bilet>> invalid = change => { var b = Ticket(2); change(b); Reject(() => Store.BiletleriKaydet("deneme", new[] { b })); };
        invalid(b => b.Isim = " "); invalid(b => b.Soyisim = "");
        invalid(b => b.Telefon = "555123"); invalid(b => b.Telefon = "abcdefghij");
        invalid(b => b.Telefon = "05551234567"); invalid(b => b.Cinsiyet = "");
        invalid(b => b.Tarih = DateTime.Today.AddDays(-1));
        invalid(b => b.Nereye = b.Nereden); invalid(b => b.Nereye = "not a station");
        invalid(b => b.Tren = "not a train"); invalid(b => b.Fiyat = 0);
        invalid(b => b.KoltukNo = 0); invalid(b => b.KoltukNo = 46);
        invalid(b => { b.Tren = "EGE EKSPRESİ"; b.KoltukNo = 37; });
        Check(Store.BiletleriOku().Count == 3, "Invalid input modified saved data.");
    }

    private static void Concurrency()
    {
        Reject(() => Store.BiletleriKaydet("deneme", new[] { Ticket(2), Ticket(1) }));
        Check(!Store.BiletleriOku().Any(b => b.KoltukNo == 2), "Failed batch partially persisted.");
        Reject(() => Store.BiletleriKaydet("deneme", new[] { Ticket(3), Ticket(3) }));
        Check(!Store.BiletleriOku().Any(b => b.KoltukNo == 3), "Same-batch duplicate persisted.");
        string exe = Assembly.GetExecutingAssembly().Location;
        var start = new ProcessStartInfo(exe, "worker \"" + Path.Combine(root, "data.xml") + "\"")
            { UseShellExecute = false, CreateNoWindow = true, WindowStyle = ProcessWindowStyle.Hidden };
        using (var a = Process.Start(start)) using (var b = Process.Start(start))
        {
            Check(a.WaitForExit(15000) && b.WaitForExit(15000), "Concurrent saves timed out.");
            Check(new[] { a.ExitCode, b.ExitCode }.OrderBy(x => x).SequenceEqual(new[] { 0, 2 }), "Two processes reserved the same seat.");
        }
        Check(Store.BiletleriOku().Count(b => b.KoltukNo == 20) == 1, "Concurrent duplicate stored.");
        Check(File.Exists(Path.Combine(root, "data.xml.bak")), "Previous snapshot backup missing.");
    }

    private static void StorageFailures()
    {
        string corrupt = Path.Combine(root, "corrupt.xml");
        File.WriteAllText(corrupt, "<broken");
        var store = new VeriDeposu(corrupt);
        IoReject(() => store.BiletleriOku());
        IoReject(() => store.KayitOl("user", "Password123!"));
        Check(File.ReadAllText(corrupt) == "<broken", "Corrupt data overwritten.");
        string blocker = Path.Combine(root, "file-not-folder"); File.WriteAllText(blocker, "keep");
        IoReject(() => new VeriDeposu(Path.Combine(blocker, "data.xml")).KayitOl("user", "Password123!"));
        Check(File.ReadAllText(blocker) == "keep", "Failed write modified existing file.");
    }

    private static T Control<T>(Form form, string name) where T : System.Windows.Forms.Control
    {
        return (T)form.Controls.Find(name, true).Single();
    }
    private static void Snapshot(Form form, string file)
    {
        form.ShowInTaskbar = false;
        form.StartPosition = FormStartPosition.Manual;
        form.Location = new Point(-20000, -20000);
        form.Show();
        Application.DoEvents();
        using (var bitmap = new Bitmap(form.Width, form.Height))
        {
            form.DrawToBitmap(bitmap, new Rectangle(Point.Empty, bitmap.Size));
            bitmap.Save(Path.Combine(root, file));
        }
        form.Hide();
    }
    private static void Forms()
    {
        Application.EnableVisualStyles();
        using (var login = new GirisForm())
        {
            Check(Control<TextBox>(login, "txtGirisParola").UseSystemPasswordChar, "Login password visible.");
            Check(Control<TextBox>(login, "txtKayitParola").UseSystemPasswordChar, "Registration password visible.");
            Snapshot(login, "login.png");
        }
        using (var menu = new AnaMenuForm(Store, "deneme"))
        using (var about = new HakkindaForm())
        using (var schedule = new TrenSaatleriForm())
        using (var passenger = new YolcuBilgileriForm())
        {
            var phone = Control<MaskedTextBox>(passenger, "mskdTelefon"); phone.Text = "5551234567";
            Check(passenger.Telefon == "5551234567", "Phone mask includes literals.");
        }
        using (var tickets = new BiletAlForm(Store, "deneme"))
        {
            Control<DateTimePicker>(tickets, "dtpTarih").Value = DateTime.Today.AddDays(2);
            var trains = Control<ComboBox>(tickets, "cmbTren"); trains.SelectedIndex = 0;
            var panel = tickets.Controls.OfType<Panel>().Single();
            Check(panel.Controls.OfType<Button>().Count() == 45, "Wrong seat count.");
            Check(!panel.Controls.OfType<Button>().Single(b => b.Text == "1").Enabled, "Saved seat is selectable.");
            trains.SelectedIndex = 1;
            Check(panel.Controls.OfType<Button>().Count() == 36, "Old train seats retained.");
            Control<DateTimePicker>(tickets, "dtpTarih").Value = DateTime.Today.AddDays(5);
            Check(panel.Controls.OfType<Button>().All(b => b.Enabled), "Different date remains occupied.");
            Check(Control<ListView>(tickets, "listView1").Items.Count == 4, "Saved tickets not loaded.");
            var pending = (System.Collections.Generic.List<Bilet>)typeof(BiletAlForm).GetField("bekleyenler", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(tickets);
            pending.Add(Ticket(5));
            Check((bool)typeof(BiletAlForm).GetMethod("Kaydet", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(tickets, null), "Save action failed.");
            Check(Store.BiletleriOku().Any(b => b.KoltukNo == 5) && pending.Count == 0, "Save action did not persist/clear pending tickets.");
            trains.SelectedIndex = 0;
            Control<DateTimePicker>(tickets, "dtpTarih").Value = DateTime.Today.AddDays(2);
            Snapshot(tickets, "tickets.png");
        }
        using (var other = new BiletAlForm(Store, "ikinci"))
        {
            Control<ComboBox>(other, "cmbTren").SelectedIndex = 0;
            Check(Control<ListView>(other, "listView1").Items.Count == 0, "Other user's passenger details shown.");
        }
    }
}

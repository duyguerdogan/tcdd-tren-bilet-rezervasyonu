using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class TrenSaatleriForm : Form
    {
        //Anahtar olarak durak isimlerini ve değer olarak bu duraklara ait tren saatlerini tutan bir sözlük.
        private Dictionary<string, List<TimeSpan>> trainSchedules;

        public TrenSaatleriForm()
        {
            InitializeComponent();
            Text = "Tren Saatleri (Örnek Tarife)";
            InitializeTrainSchedules();
            PopulateStations();
        }

        

        private void InitializeTrainSchedules()
        {
            //Her durak için tren saatleri List<TimeSpan> olarak belirtilir.
            trainSchedules = new Dictionary<string, List<TimeSpan>>
            {
                { "Ankara Gar", new List<TimeSpan> { new TimeSpan(20, 0, 0) } },
                { "Sincan", new List<TimeSpan> { new TimeSpan(20, 21, 0) } },
                { "Polatlı", new List<TimeSpan> { new TimeSpan(21, 5, 0) } },
                { "Beylikköprü", new List<TimeSpan> { new TimeSpan(21, 25, 0) } },
                { "Biçer", new List<TimeSpan> { new TimeSpan(21, 50, 0) } },
                { "Yunusemre", new List<TimeSpan> { new TimeSpan(22, 10, 0) } },
                { "Beylikova", new List<TimeSpan> { new TimeSpan(22, 31, 0) } },
                { "Alpu", new List<TimeSpan> { new TimeSpan(22, 49, 0) } },
                { "Eskişehir", new List<TimeSpan> { new TimeSpan(23, 25, 0) } },
                { "Kütahya", new List<TimeSpan> { new TimeSpan(0, 39, 0) } },
                { "Tavşanlı", new List<TimeSpan> { new TimeSpan(1, 27, 0) } },
                { "Balıköy", new List<TimeSpan> { new TimeSpan(2, 18, 0) } },
                { "Dursunbey", new List<TimeSpan> { new TimeSpan(3, 24, 0) } },
                { "Balıkesir", new List<TimeSpan> { new TimeSpan(5, 12, 0) } },
                { "Savaştepe", new List<TimeSpan> { new TimeSpan(6, 0, 0) } },
                { "Soma", new List<TimeSpan> { new TimeSpan(6, 28, 0) } },
                { "Kırkağaç", new List<TimeSpan> { new TimeSpan(6, 38, 0) } },
                { "Akhisar", new List<TimeSpan> { new TimeSpan(7, 05, 0) } },
                { "Saruhanlı", new List<TimeSpan> { new TimeSpan(7, 29, 0) } },
                { "Manisa", new List<TimeSpan> { new TimeSpan(7, 53, 0) } },
                { "Muradiye", new List<TimeSpan> { new TimeSpan(8, 10, 0) } },
                { "Menemen", new List<TimeSpan> { new TimeSpan(8, 40, 0) } },
                { "Çiğli", new List<TimeSpan> { new TimeSpan(8, 57, 0) } },
                { "İzmir(Basmane)", new List<TimeSpan> { new TimeSpan(9, 25, 0) } },
            };
        }

        private void PopulateStations()
        {
            cmbStations.Items.AddRange(trainSchedules.Keys.ToArray());// durakları combobox a ekledik.
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string selectedStation = cmbStations.SelectedItem as string; //ComboBox'tan seçilen durağın ismini alır.

            if (string.IsNullOrEmpty(selectedStation) || !trainSchedules.ContainsKey(selectedStation)) //Eğer geçerli bir durak seçilmemişse, kullanıcıya uyarı mesajı gösterir.
            {
                MessageBox.Show("Lütfen geçerli bir durak seçin.");
                return;
            }

            List<TimeSpan> times = trainSchedules[selectedStation]; //Seçilen durağın tren saatlerini times listesine alır
            TimeSpan now = DateTime.Now.TimeOfDay; //Şu anki zamanı alır.
            List<TimeSpan> todaysTimes = times.Where(time => time > now).ToList(); //Bugün içinde henüz geçmemiş tren saatlerini filtreler.
            //Bugün geçerli olan, ancak artık geçmiş tren saatlerini yarınki zaman dilimine ekler.
            List<TimeSpan> nextDayTimes = times.Where(time => time <= now).Select(time => time.Add(new TimeSpan(24, 0, 0))).ToList();

            List<TimeSpan> combinedTimes = todaysTimes.Concat(nextDayTimes).ToList();  //Bugün ve yarınki tren saatlerini birleştirir.

            TimeSpan nextTrainTime = combinedTimes.OrderBy(time => time).FirstOrDefault(); //İlk uygun tren saatini bulur.

            // Kullanıcıya mesajı gösteriyoruz
            if (nextTrainTime == default(TimeSpan))
            {
                lblArrivalTime.Text = "Bugün başka tren yok.";
            }
            else
            {
                TimeSpan timeUntilNextTrain = nextTrainTime - now;
                lblArrivalTime.Text = $"Bir sonraki tren {(int)timeUntilNextTrain.TotalHours} saat {timeUntilNextTrain.Minutes} dakika sonra gelecek.";
            }
        }

        

        

        

        
    }
}


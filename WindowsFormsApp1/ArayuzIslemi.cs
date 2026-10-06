using System;
using System.IO;
using System.Security;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class ArayuzIslemi
    {
        public static bool Dene(IWin32Window sahip, Action islem)
        {
            try { islem(); return true; }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(sahip, ex.Message, "İşlem tamamlanamadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is SecurityException)
            {
                MessageBox.Show(sahip, "Kayıtlara erişilemedi.\n" + ex.Message, "Dosya hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
    }
}

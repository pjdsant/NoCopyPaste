using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;


/*Developer by Paulo Santos.
/ email: pjdsant@gmail.com
/ Prevent users to use Ctrl C and Ctrl V.
*/
namespace NoCopyPaste
{
    class Program
    {
        [DllImport("user32.dll", EntryPoint = "MessageBox")]
        public static extern int MessageBoxUser32(int hWnd, String text, String caption, uint type);

        const uint MB_TOPMOST = 0x00040000;

        [STAThreadAttribute]
        static void Main(string[] args)
        {
            var p = new Program();
            p.DisableCC();
        }

        public void DisableCC()
        {
            while (true)
            {
                try
                {
                    Clipboard.GetText();
                    Clipboard.Clear();
                }
                catch (System.Exception ex)
                {
                    if (!AppSettings.DisabilitarMessagem)
                        MessageBoxUser32(0, "ATENÇÂO!!!", "CTRL + C É BLOQUEADO! \r" + ex.Message.ToString(), MB_TOPMOST);
                }
                finally
                {
                    Thread.Sleep(AppSettings.TimeSleep);
                }

            }
        }
        

    }
}

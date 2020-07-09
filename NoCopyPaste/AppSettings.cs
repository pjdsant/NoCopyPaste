using System.Configuration;

namespace NoCopyPaste
{
    public class AppSettings
    {
        public static int TimeSleep { get { return int.Parse(ConfigurationManager.AppSettings["TimeSleep"]); } }
        public static bool DisabilitarMessagem { get { return bool.Parse(ConfigurationManager.AppSettings["DisabilitarMessagem"]); } }

    }
}

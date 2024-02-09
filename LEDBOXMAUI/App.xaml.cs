using LEDBOXMAUI.Interfaces;
using LEDBOXMAUI.Model;
using LEDBOXMAUI.Resources;

namespace LEDBOXMAUI
{
    public partial class App : Application
    {
        /// <summary>
        /// Gestore delle API con il LEDbox
        /// </summary>
        public static APILedbox api;
        /// <summary>
        /// Nome utente corrente
        /// </summary>
        public static string alias = "";
        /// <summary>
        /// Sport corrente
        /// </summary>
        public static sport sport = null;
        /// <summary>
        /// Connessione corrente con il LEDbox (Bluetooth o Wifi)
        /// </summary>
        public static ConnectionInterface conn;
        public static MainPage main;

        /// <summary>
        /// Nome del LEDbox corrente
        /// </summary>
        public static string deviceName;
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }


        public static void DisplayAlert(string message)
        {
            App.main.DisplayAlert(AppResources.warning, message, AppResources.ok);
        }
    }
}

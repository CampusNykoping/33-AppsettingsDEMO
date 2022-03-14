namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }

    // Steg 1 - lägg till klasser för konfiguration
    public class Config
    {
        public bool DebugEnabled { get; set; }
        public WeatherClientConfig WeatherClientConfig { get; set; }
    }

    public class WeatherClientConfig
    {
        public bool IsEnabled { get; set; }
        public string WeatherAPIUrl { get; set; }
        public int Timeout { get; set; }

        public TemperatureUnits TemperatureUnits { get; set; }
    }

    public enum TemperatureUnits
    {
        Kelvin,
        Fahrenheit,
        Celsius
    }
}
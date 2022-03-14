using Microsoft.Extensions.Configuration;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {    
        public Form1()
        {
            InitializeComponent();

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {            
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Steg 2: Läs in konfiguration från Appsettings.json

            var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build()
            .Get<Config>();

            // Steg 3: Ändra på några värden
            config.WeatherClientConfig.Timeout = 1000;
            config.WeatherClientConfig.TemperatureUnits = TemperatureUnits.Celsius;

            config.DebugEnabled = bool.Parse(textBox1.Text);

            // Serialisera konfigurationsobjektet och skriv över filen
            var jsonWriteOptions = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            jsonWriteOptions.Converters.Add(new JsonStringEnumConverter());

            var newJson = JsonSerializer.Serialize(config, jsonWriteOptions);

            var appSettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
            File.WriteAllText(appSettingsPath, newJson);
        }
    }
}
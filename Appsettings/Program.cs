using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using System.Dynamic;

// Steg 1: Läs in appsettings.json och konvertera till ett dynamiskt objekt
var appSettingsPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "appsettings.json");
var json = File.ReadAllText(appSettingsPath);

var jsonSettings = new JsonSerializerSettings();
jsonSettings.Converters.Add(new ExpandoObjectConverter());
jsonSettings.Converters.Add(new StringEnumConverter());

dynamic config = JsonConvert.DeserializeObject<ExpandoObject>(json, jsonSettings);


// Steg 2: Ändra väreden i konfigurationsdata
config.DebugEnabled = true;
config.WeatherClientConfig.TemperatureUnits = TemperatureUnits.Fahrenheit;


// Lägg till ny egenskap i appsettings.json
var expando = config as IDictionary<string, object>;
expando.Add("Updated", DateTime.Now);

// Ta bort en egenskap ur appsettings.json
expando.Remove("DebugEnabled");


// Steg 3: Serialisera objektet config och skriv över appsettings.json
var newJson = JsonConvert.SerializeObject(config, Formatting.Indented, jsonSettings);

File.WriteAllText(appSettingsPath, newJson);



Console.WriteLine("Tryck på en tangent");
Console.ReadKey();



public enum TemperatureUnits
{
	Kelvin,
	Fahrenheit,
	Celsius
}
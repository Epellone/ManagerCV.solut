using ManagerCV.Model;
using Microsoft.AspNetCore.Mvc;

namespace EsercizioAPI.Controllers
{
    [ApiController] //indica che la classe è un controller per un'API 
    [Route("[controller]")] //specifica il modello di routing per il controller, il nojme tra parentesi quadre verrà sostituito in automatico con il nome del nostro controller
    public class WeatherForecastController : ControllerBase //classe wheaterforecast è un controller per un'API che fornisce due endpoint: uno per ottenere previsioni meteo casuali per un intervallo di giorni e l'altro per ottenere previsioni meteo casuali per una data specifica
    {
        private static readonly string[] Summaries = new[] //viene dichiarato un array di stringe che contiene delle descrizioni predefinite del meteo che verranno richiamtate successivamente in modo random
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger; //sulla parte logger non ci abbiamo lavorato 

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")] //  Questo attributo viene utilizzato per mappare un metodo di un controller a un'azione HTTP GET e assegnargli un nome specifico.
        public IEnumerable<WeatherForecast> Get() //metodo get che restituisce una serie di previsioni meteo casuali per i prossimi 5 giorni, utilizzando l'oggetto WeatherForecast
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        //parte aggiunta 
        [HttpGet("{anno}/{mese}/{giorno}")] 
        public IEnumerable<WeatherForecast> GetByDate(int anno, int mese, int giorno) //metodo che genera una serie di previsioni meteo casuali per i prossimi 5 giorni a partire dalla data specificata dai parametri anno, mese, giorno
        {
            DateTime data = new DateTime(anno, mese, giorno); //oggetto DateTime per creare la data corretta
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast //range 1, 5, ritorna 5 previsioni
            {
                Date = data.AddDays(index), //AddDays aggiunge 1 al giorno che inserisco  
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
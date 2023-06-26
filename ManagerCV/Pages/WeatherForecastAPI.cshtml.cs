using ManagerCV.Model; // da inserire
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ManagerCV.Pages
{
    public class WeatherForecastAPIModel : PageModel //classe weatherforecastapimodel
    {
        private static HttpClient client = new() //viene utilizzato per effettuare richieste HTTP all'API remota
        {
            BaseAddress = new Uri("https://localhost:7114") //uri=rappresenta l'URL di base dell'API a cui verranno inviate le richieste.
                                                            //la trovate nel progetto del controller API nel file lunchsetting ed è diverso per ognuno
                                                            //indica la porta https a cui ci si collega 
        };

        private string Uri = "WeatherForecast"; //rappresenta il percorso dell'endpoint dell'API. Possiamo anche non dichiare la stringa ed inserire direttamente il nome
                                                //ma questo ci farà comodo quando dobbiamo richiamarlo
        public List<WeatherForecast> Lista { get; set; } //proprietà che rappresenta una lista di oggetti weatherforecast 

        [BindProperty] //questo attributo indica che la proprietà DateTime verrà utilizzata per il binding dei dati ricevuti dalla richiesta HTTP
        public DateTime Data { get; set; }

        public WeatherForecastAPIModel() //costruttore 
        {
            Lista = new List<WeatherForecast>();
            Data = DateTime.Now;
        }

        public async void OnGet() //metodo con chiamata async (asincrona =metodo che può essere eseguito in modo non bloccante rispetto all' esecuzione principale del programma)
                                  //per ottenere una lista di oggetti weatherforecast dall'endpoint specificato da Uri
        {
            Lista = await client.GetFromJsonAsync<List<WeatherForecast>>(Uri); //Viene poi effettuata una chiamata asincrona a client.GetFromJsonAsync() utilizzando la stringa test come URL.
                                                                               //Il risultato viene assegnato alla lista.
        }
        public async Task<IActionResult> OnPost() // Indica che il metodo restituisce un'istanza di tipo "Task"
                                                  // che rappresenta un'operazione asincrona in corso e che restituirà un oggetto di tipo "IActionResult" una volta completata
        {
            var test = $"{Uri}/{Data.Year}/{Data.Month}/{Data.Day}"; //interpolazione di striga con $ che è come scrivere Uri + "/" + Data.Year + "/" + Data.Month  + "/" + Data.Day
            Lista = await client.GetFromJsonAsync<List<WeatherForecast>>(test); //chiamata asincrona per questo utilizzo await.
                                                                                //Interroga test e ritorna <List>WeatherForecast>> deserializzando il json

            return Page();
        }
    }
}

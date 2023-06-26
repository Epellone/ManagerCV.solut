using ManagerCV.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace ManagerCV.Pages
{
    public class TitoliModel : PageModel
    {
        public List<Titolo> Elenco { get; set; }

        public TitoliModel()
        {
            string nomeFile = "./wwwroot/json/listatitoli.json";

            using (FileStream fs = System.IO.File.OpenRead(nomeFile)) 
            {
                var obj = JsonSerializer.Deserialize<Titoli>(fs);

                Elenco = obj.ListaTitoli;
            }
        }
        public void OnGet()
        {
        }
    }
}

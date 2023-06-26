using ManagerCV.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Text.Json;

namespace ManagerCV.Pages
{
    public class SediModel : PageModel
    {
        public List<Sede> Lista { get; set; }

        [BindProperty]
        public  string Descrizione { get; set; }

        [BindProperty]
        public  string Indirizzo { get; set; }       
        
        [BindProperty]
        public  string Città { get; set; }        
        
        [BindProperty]
        public  string Provincia { get; set; }       
        
        [BindProperty]
        public  string Cap { get; set; }  
        
        [BindProperty]
        public  string RecapitoTel { get; set; }  
        
        [BindProperty]
        public  string Email { get; set; }


        public SediModel()
        {
            Lista = new List<Sede>();
        }

        public void OnGet()
        {

        }

        public  IActionResult OnPost()
        {
            string nomeFile = "./wwwroot/json/listasedi.json";

            using (FileStream fs = System.IO.File.OpenRead(nomeFile)) //FileStream classe, System.IO.File classe che mi permette di accedere ad un file che ho su un disco/drive
            {
                var obj = JsonSerializer.Deserialize<Sedi>(fs); //JsonSerializer classe a cui accedo utilizzando il metodo Deserialize che prende in input un file e lo converte in un oggetto di .Net

                Lista = obj.ListaSedi;
                {
                    if(!string.IsNullOrWhiteSpace(Descrizione))
                    {
                        Lista = Lista.Where(x => x.Descrizione.ToLower().Contains(Descrizione)).ToList();
                    }

                    if (!string.IsNullOrWhiteSpace(Indirizzo))
                    {
                        Lista = Lista.Where(x => x.Indirizzo.ToLower().Contains(Indirizzo)).ToList();
                    }

                    if (!string.IsNullOrWhiteSpace(Città))
                    {
                        Lista = Lista.Where(x => x.Città.ToLower().Contains(Città)).ToList();
                    }

                    if (!string.IsNullOrWhiteSpace(Provincia))
                    {
                        Lista = Lista.Where(x => x.Provincia.ToLower().Contains(Provincia)).ToList();
                    }

                    if (!string.IsNullOrWhiteSpace(Cap))
                    {
                        Lista = Lista.Where(x => x.Cap.ToLower().Contains(Cap)).ToList();
                    }

                    if (!string.IsNullOrWhiteSpace(RecapitoTel))
                    {
                        Lista = Lista.Where(x => x.RecapitoTel.ToLower().Contains(Città)).ToList();
                    }

                    if (!string.IsNullOrWhiteSpace(Email))
                    {
                        Lista = Lista.Where(x => x.Email.ToLower().Contains(Città)).ToList();
                    }
                }//associo la mappatura del file in input alla property Lista
            }
            return Page();
        }
    }
}

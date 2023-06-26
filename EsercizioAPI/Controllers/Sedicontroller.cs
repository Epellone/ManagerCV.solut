using ManagerCV.Model; //da aggiungere con il nome del progetto iniziale che avete creato 
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EsercizioAPI.Controllers
{
    [Route("api/[controller]")] // il controller all'interno delle parentesi quadre viene modificato con il nome del nostro controller
    [ApiController]
    public class Sedicontroller : ControllerBase
    {
        public List<Sede> ListaSedi { get; set; } //Viene dichiarata una proprietà che rappresenta una lista di oggetti di tipo Sede.


        [HttpGet(Name = "GetSedi")] //template che ci indica qualcosa che viene aggiunto alla route e serve per passare parametri 
        public IEnumerable<Sede> Get() //il codice interno a questo metodo lo abbiamo copiato dal file sedi.cshtml.cs
                                       //All'interno del metodo, viene specificato un percorso di file (nomeFile) che punta a un file JSON contenente una lista di oggetti Sede.
                                       //Utilizzando un oggetto FileStream e JsonSerializer, il file JSON viene deserializzato in un oggetto Sedi che contiene la lista di oggetti Sede
        {
            string nomeFile = "C:\\Users\\Pello\\source\\repos\\ManagerCV.solut\\ManagerCV\\wwwroot\\json\\listasedi.json";

            using (FileStream fs = System.IO.File.OpenRead(nomeFile)) //FileStream classe, System.IO.File classe che mi permette di accedere ad un file che ho su un disco/drive
            {
                var obj = JsonSerializer.Deserialize<Sedi>(fs); //JsonSerializer classe a cui accedo utilizzando il metodo Deserialize che prende in input un file e lo converte in un oggetto di .Net

                return ListaSedi = obj.ListaSedi;
            }
        }

        [HttpGet(template: "{città}", Name = "GetCittà")]
        public IEnumerable<Sede> GetCittà(string città) //questo metodo è specifico per le città e quindi utilizzeremo una query linq per filtrare solo quelli che corrispondono alla città specificata all'interno di listasedi
        {
            string nomeFile = "C:\\Users\\Pello\\source\\repos\\ManagerCV.solut\\ManagerCV\\wwwroot\\json\\listasedi.json";

            using (FileStream fs = System.IO.File.OpenRead(nomeFile)) 
            {
                var obj = JsonSerializer.Deserialize<Sedi>(fs);

                return (from Sede in obj.ListaSedi
                        where Sede.Città == città
                        select Sede).ToList();
            }

        }
    }
}

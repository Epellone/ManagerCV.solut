using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ManagerCV.Model;

namespace ManagerCV.Pages
{
    public class SediAPIModel : PageModel
    {
        private static HttpClient client = new()
        {
            BaseAddress = new Uri("https://localhost:7114")
        };

        private string uri = "api/Sedi"; 

        public List<Sede> Lista { get; set; }

        public SediAPIModel()
        {
            Lista = new List<Sede>();
        }

       public async Task<IActionResult> OnGet()
        {
            Lista = await client.GetFromJsonAsync<List<Sede>>(uri);
      
            return Page();
        }
    }
}

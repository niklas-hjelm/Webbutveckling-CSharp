using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstWebApp.Pages
{
    public class DemoModel : PageModel
    {
        public int Test { get; set; } = 1;

        public void OnGet()
        {
        }
    }
}

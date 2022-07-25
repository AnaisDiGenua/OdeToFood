using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;

        public string Message { get; set; }

        public ListModel(IConfiguration config)
        {
            this.config = config;
        }

        //httpGet request
        public void OnGet()
        {
            Message = config["Message"];
        }
    }
}

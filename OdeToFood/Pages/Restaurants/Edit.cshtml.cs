using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        //entit�
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? restaurantId)
        {
            //tramite questo tag helper prendo la lista di enum
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            if(restaurantId.HasValue)
            {
                //assoccio l'entit� restaurant al ristorante scelto dall'utente tramite id
                Restaurant = restaurantData.GetById(restaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }

            //se il ristorante non esiste pi�
            if (Restaurant == null)
                return RedirectToPage("./NotFound");
            return Page();
        }

        public IActionResult OnPost()
        { 

            if(!ModelState.IsValid)
            {
                //tramite questo tag helper prendo la lista di enum
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            if(Restaurant.Id > 0)
            {
                restaurantData.Update(Restaurant);
            }
            else
            {
                restaurantData.Add(Restaurant);
            }

            restaurantData.Commit();
            TempData["Message"] = "Restaurant saved!";

            return RedirectToPage("./Detail", new { RestaurantId = Restaurant.Id }); //simile a  laravel

        }
    }
}

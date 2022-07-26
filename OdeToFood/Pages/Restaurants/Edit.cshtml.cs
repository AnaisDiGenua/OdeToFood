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
        public IActionResult OnGet(int restaurantId)
        {
            //tramite questo tag helper prendo la lista di enum
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            //assoccio l'entit� restaurant al ristorante scelto dall'utente tramite id
            Restaurant = restaurantData.GetById(restaurantId);

            //se il ristorante non esiste pi�
            if (Restaurant == null)
                return RedirectToPage("./NotFound");
            return Page();
        }

        public IActionResult OnPost()
        { 

            if(ModelState.IsValid)
            {
                restaurantData.Update(Restaurant);
                restaurantData.Commit();
            }


            //tramite questo tag helper prendo la lista di enum
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            return Page();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;

namespace OdeToFood.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        private readonly IRestaurantData restaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        //simile a mvc != razor page
        public IViewComponentResult Invoke()
        {
            var count = restaurantData.GetCountOfRstaurants();

            //ritorno una vista. In questo modo tra parentesi passo il model di cui ho bisogno => nella razor page avrei messo il count come proprietà e fatto un binding con la pagine cshtml
            return View(count);
        }
    }
}

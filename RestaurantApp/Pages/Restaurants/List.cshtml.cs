using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RestaurantApp.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public string Message;
        public void OnGet()
        {
            Message = "Hello World";
        }
    }
}

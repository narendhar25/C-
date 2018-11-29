using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.ViewComponents
{
    public class RegistrationViewComponent : ViewComponent
    {
        public RegistrationViewComponent()
        {

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();
            keyValuePairs.Add(1, "one");
            keyValuePairs.Add(2, "two");
            keyValuePairs.Add(3, "three");
            keyValuePairs.Add(4, "four");
            keyValuePairs.Add(5, "five");
            keyValuePairs.Add(6, "six");
            keyValuePairs.Add(7, "seven");
            keyValuePairs.Add(8, "eight");
            keyValuePairs.Add(9, "nine");
            keyValuePairs.Add(10, "ten");
            var dropdownvalues = await Task.Run(() => keyValuePairs);
            return View(dropdownvalues);
        }
    }
}

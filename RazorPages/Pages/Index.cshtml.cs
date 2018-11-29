using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Pages.Shared;

namespace RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        public _MyPartialModel partialModel { get; set; }
        [BindProperty]
        public string BindData { get; set; }
        public void OnGet()
        {
            partialModel = new _MyPartialModel();
        }
        public void OnPost()
        {

        }
    }
}

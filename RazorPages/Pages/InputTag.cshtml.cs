using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Entities;

namespace RazorPages.Pages
{
    public class InputTagModel : PageModel
    {
        [BindProperty]
        public Member member { get; set; }
        public void OnGet()
        {

        }
    }
}
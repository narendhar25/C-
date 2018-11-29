using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Entities;
using RazorPages.Pages.Shared;

namespace RazorPages.Pages.Emp
{
    public class RegistrationModel : PageModel
    {
        [BindProperty]
        [ViewData]
        public string Message { get; set; } = "Initial Request";
        [BindProperty(SupportsGet =true)]
        public string BindData{get;set;}
        [TempData]
        public string MyTempData { get; set; }
        public _MyPartialModel partialModel { get; set; }
        public void OnGet()
        {
            MyTempData = "Value from TempData";
            partialModel = new _MyPartialModel();
        }
        public void OnGetValues()
        {
            ViewData["MyValue"] = "Message from ViewData";
            
        }
        public IActionResult OnPost()
        {
            return Page();
        }
        public IActionResult OnPostAdd(int id,string name)
        {
            if (ModelState.IsValid)
            {
                return Page();
            }
            return RedirectToPage("../Index");
        }

        //public void OnPostDelete()
        //{
        //    Message = "Delete handler fired";
        //}

        //public void OnPostEdit(int id)
        //{
        //    Message = "Edit handler fired";
        //}

        public void OnPostMyMethod(int id)
        {
            Message = $"View handler fired {id}";
        }

        public void OnGetEdit(int id)
        {

        }
        public void OnGetDelete(int id)
        {

        }

      
    }
}
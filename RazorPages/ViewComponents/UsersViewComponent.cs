using Microsoft.AspNetCore.Mvc;
using RazorPages.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.ViewComponents
{
    public class UsersViewComponent : ViewComponent
    {
        private IUserService _userService;

        public UsersViewComponent(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var users = await _userService.GetUserAsync(id);
            return View(users);
        }
    }
}

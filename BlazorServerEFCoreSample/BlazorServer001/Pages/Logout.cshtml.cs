using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace BlazorServer001.Pages
{
    public class LogoutModel : PageModel
    {
        //public async Task<IActionResult> OnGetAsync()

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    await HttpContext
        //        .SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    return LocalRedirect(Url.Content("~/"));
        //}
        public async Task<IActionResult> OnPostAsync()
        {
            await HttpContext
                .SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect(Url.Content("~/"));
        }
        //public async Task<IActionResult> OnGetAsync()
        //{
        //    await HttpContext
        //        .SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    return LocalRedirect(Url.Content("~/"));
        //}
    }
}

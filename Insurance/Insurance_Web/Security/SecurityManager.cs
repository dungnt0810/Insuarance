using Insurance_Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Insurance_Web.Areas.Admin.Security
{
    public class SecurityManager
    {
        private IEnumerable<Claim> GetClaimOfEmployee(Employee employee)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, employee.Email));
            string role;
            using (var db = new OnlineInsuranceDBContext())
            {
                role = db.Role.Find(employee.IdRole).Name;
            };
            claims.Add(new Claim(ClaimTypes.Role, role));
            return claims;
        }

        public async void SignIn(HttpContext httpContext, Employee employee)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(GetClaimOfEmployee(employee), CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
        }

        public async void SignOut(HttpContext httpContext) => await httpContext.SignOutAsync();
    }
}

using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using DreamLib.Models;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using DreamLib.Repositories;
using System.Data.Entity;

[assembly: OwinStartup(typeof(DreamLib.App_Start.Startup))]

namespace DreamLib.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.SetInitializer(new AppDbInitializer());

            app.CreatePerOwinContext(ApplicationContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}

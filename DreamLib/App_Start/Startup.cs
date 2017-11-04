﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using DreamLib.Models;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using DreamLib.Repositories;

[assembly: OwinStartup(typeof(DreamLib.App_Start.Startup))]

namespace DreamLib.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.CreatePerOwinContext<ApplicationContext>(ApplicationContext.Create);
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

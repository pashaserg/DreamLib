using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using DreamLib.Models;

namespace DreamLib.Repositories
{
    public class ApplicationContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("LibraryContext") { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}
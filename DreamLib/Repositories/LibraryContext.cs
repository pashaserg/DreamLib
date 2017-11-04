using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DreamLib.Models;

namespace DreamLib.Repositories
{
    public class LibraryContext: DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Artist> Artists { get; set; } 
    }
}
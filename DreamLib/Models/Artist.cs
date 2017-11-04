using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DreamLib.Models
{
    public class Artist
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Name { get; set; }


        public virtual ICollection<Song> Songs { get; set; }
        public Artist()
        {
            Songs = new List<Song>();
        }
    }
}
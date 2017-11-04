using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DreamLib.Models
{
    public class Song
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Song must have a name")]
        public string Name { get; set; }
        public string Src { get; set; }
        public string Cover { get; set; }

        [ScaffoldColumn(false)]
        public int? ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DreamLib.Models
{
    public class EditSongModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Song must have a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Song must have an artist name")]
        public string ArtistName { get; set; }
        public string Src { get; set; }
        public string Cover { get; set; }
    }
}
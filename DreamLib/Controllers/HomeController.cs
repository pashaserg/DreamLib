using DreamLib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DreamLib.Models;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DreamLib.Controllers
{
    public class HomeController : Controller
    {

        LibraryContext db = new LibraryContext();

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> SongList()
        {
            IEnumerable<Song> songs = await db.Songs.AsNoTracking().ToListAsync();
            ViewBag.SongsCnt = songs.Count();
            ViewBag.ArtitsCnt = db.Artists.Distinct().ToArray().Count();
            return View(songs);
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddSong()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddSong(NewSongModel newSong)
        {
            if(ModelState.IsValid)
            {
                Artist artist = db.Artists.FirstOrDefault(p => p.Name == newSong.ArtistName);
                if (artist==null)
                {
                    artist = db.Artists.Add(new Artist{ Name = newSong.ArtistName});
                }
            db.Songs.Add(new Song
            {
                Name = newSong.Name,
                Src = newSong.Src,
                Cover = newSong.Cover,
                ArtistId = artist.Id
            });
            await db.SaveChangesAsync();
            return RedirectToAction("SongList");
            }
            return new HttpNotFoundResult();
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> SongDetail(int id)
        {
            Song song = await db.Songs.FirstOrDefaultAsync(p => p.Id == id);
            if (song!=null)
            {
                return View(song);
            }
            return new HttpNotFoundResult();
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> EditSong(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Song song = await db.Songs.FirstOrDefaultAsync(p => p.Id == id);
            
            if (song != null)
            {
                EditSongModel editingSong = new EditSongModel
                {
                    Id = song.Id,
                    ArtistName = song.Artist.Name,
                    Name = song.Name,
                    Cover = song.Cover,
                    Src = song.Src
                };

                return View(editingSong);
            }
            return new HttpNotFoundResult();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> EditSong(EditSongModel editingSong)
        {
            if(ModelState.IsValid)
            {
                Artist artist = db.Artists.FirstOrDefault(p => p.Name == editingSong.ArtistName);
                if (artist == null)
                {
                    artist = db.Artists.Add(new Artist { Name = editingSong.ArtistName });
                }

                Song song = db.Songs.FirstOrDefault(p => p.Id == editingSong.Id);

                song.Cover = editingSong.Cover;
                song.Name = editingSong.Name;
                song.Src = editingSong.Src;
                song.ArtistId = artist.Id;

                db.Entry(song).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            
            return RedirectToAction("SongList");
        }

        [Authorize]
        public ActionResult DeleteSong(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            db.Songs.Remove(song);
            db.SaveChanges();
            return RedirectToAction("SongList");
        }

    }
}
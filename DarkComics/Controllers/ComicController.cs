using DarkComics.DAL;
using DarkComics.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DarkComics.Controllers
{
    public class ComicController : Controller
    {
        private readonly DarkComicDbContext _context;
        public ComicController(DarkComicDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            int take = 3;

            ComicViewModel comicViewModel = new ComicViewModel
            {
                Books = _context.Comics.Include(c => c.ComicCharacters).ThenInclude(c => c.Character).Include(c => c.Category).ThenInclude(c => c.Character).
                Where(c => c.IsActive == true && c.ComicType == Helpers.Enums.ComicType.Book).ToList(),
                OneShot = _context.Comics.Include(c => c.ComicCharacters).ThenInclude(c => c.Character).Include(c => c.Category).ThenInclude(c => c.Character).
                Where(c => c.IsActive == true && c.ComicType == Helpers.Enums.ComicType.SingleCover).ToList(),
                Categories = _context.Categories.Include(c => c.Comics).Include(c => c.Character).ThenInclude(c => c.CharacterPowers).ThenInclude(c => c.Power).
                OrderBy(c => c.Id).Take(take).ToList(),
                Series = _context.Comics.Include(c => c.ComicCharacters).ThenInclude(c => c.Character).Include(c => c.Category).ThenInclude(c => c.Character).
                Where(c => c.IsActive == true && c.ComicType == Helpers.Enums.ComicType.Cover).ToList(),
            };

            int count = _context.Comics.Include(c => c.ComicCharacters).ThenInclude(c => c.Character).Include(c => c.Category).ThenInclude(c => c.Character).
                Where(c => c.IsActive == true && c.ComicType == Helpers.Enums.ComicType.Cover).Count();

            HttpContext.Response.Cookies.Append("ComicQuantity", count.ToString());

            return View(comicViewModel);
        }

        public IActionResult LoadMore(int skip,int take)
        {
            ComicViewModel comicViewModel = new ComicViewModel
            {
                Categories = _context.Categories.Include(c => c.Character).ThenInclude(c => c.CharacterPowers).ThenInclude(c => c.Power).
                OrderBy(c => c.Id).Skip(skip).Take(take).ToList()                
            };           

            
            return View("_LoadMore", comicViewModel);
        }

        public IActionResult Search(string search)
        {
            ComicViewModel comicViewModel = new ComicViewModel
            {
                Categories = _context.Categories.Include(c => c.Character).ThenInclude(c => c.CharacterPowers).ThenInclude(c => c.Power).
                OrderBy(c => c.Id).Where(c=>(c.Character.HeroName + c.Name).Contains(search)).ToList()            };

            return View("_LoadMore", comicViewModel);
        }
    }
}

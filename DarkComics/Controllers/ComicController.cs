using DarkComics.DAL;
using DarkComics.Helpers.Enums;
using DarkComics.Helpers.Methods;
using DarkComics.Models.Entity;
using DarkComics.ViewModels;
using DarkComics.ViewModels.Basket;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
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

            ComicViewModel comicViewModel = new ComicViewModel
            {              
                RandomComics = _context.Products.Include(p => p.ComicDetail).ThenInclude(cd => cd.Serie).Include(p => p.ProductCharacters).
               ThenInclude(pc => pc.Character).Where(p => p.Category == Category.Comic && p.ComicDetail.IsCover == true && p.IsActive == true && p.ComicDetail.Serie.IsDeleted == false).ToList()
            };

            int count = _context.Series.Where(s=>s.IsDeleted == false).Count();
            HttpContext.Response.Cookies.Append("comics", count.ToString());

            return View(comicViewModel);
        }
           

        public IActionResult LoadMore(int skip = 0, int take = 2)
        {
            ComicViewModel comicViewModel = new ComicViewModel
            {
                Series = _context.Series.Include(p => p.ComicDetails).ThenInclude(cd => cd.Products).ThenInclude(p => p.ProductCharacters).
               ThenInclude(pc => pc.Character).Where(s => s.IsDeleted == false).OrderBy(s => s.Id).Skip(skip).Take(take).ToList()
            };


            return View("_LoadMore", comicViewModel);
        }

        public IActionResult Search(string search)
        {
            ComicViewModel comicViewModel = new ComicViewModel
            {
                Series = _context.Series.Include(p => p.ComicDetails).ThenInclude(cd => cd.Products).ThenInclude(p => p.ProductCharacters).
               ThenInclude(pc => pc.Character).Where(s => s.IsDeleted == false).OrderBy(c => c.Id).Where(s=>s.Name.Contains(search)).ToList()
            };

            return View("_LoadMore", comicViewModel);
        }

        public IActionResult FilterSerie(int? id)
        {
            if (id == null)
                return NotFound();

            ComicViewModel comicViewModel = new ComicViewModel
            {
                Comics = _context.Products.Include(p => p.ComicDetail).ThenInclude(cd => cd.Serie).Include(p => p.ProductCharacters).
               ThenInclude(pc => pc.Character).Where(p => p.Category == Category.Comic && p.ComicDetail.IsCover == true && p.IsActive == true && p.ComicDetail.Serie.IsDeleted == false && p.ComicDetail.Serie.Id == id).ToList()
          };

            if (comicViewModel.Comics == null)
                return BadRequest();

            return View(comicViewModel);
        }
    }
}

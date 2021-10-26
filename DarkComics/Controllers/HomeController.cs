using DarkComics.DAL;
using DarkComics.Models;
using DarkComics.Models.Entity;
using DarkComics.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DarkComics.Controllers
{
    public class HomeController : Controller
    {
        private readonly DarkComicDbContext _context;
        public HomeController(DarkComicDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                Comics = _context.Comics.Include(c=>c.ComicCharacters).ThenInclude(c=>c.Character).Include(c=>c.Category).ToList()
            };
            
            return View(homeViewModel);
        }
        public IActionResult Detail(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            Comic comic = _context.Comics.Include(c => c.ComicCharacters).ThenInclude(c => c.Character).
                Include(c => c.Category).FirstOrDefault(c=>c.Id == id);

            if (comic == null)
            {
                return NotFound();
            }
            HomeDetailViewModel homeDetailViewModel = new HomeDetailViewModel
            {
                Comic = comic
            };
                 
            return View(homeDetailViewModel);
        }

    }
}

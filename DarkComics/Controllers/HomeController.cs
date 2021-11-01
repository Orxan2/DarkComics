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
                Comics = _context.Comics.Include(c => c.ComicCharacters).ThenInclude(c => c.Character).Include(c => c.Category).
                Where(c => c.IsActive == true).ToList(),
                BestComics = _context.Comics.Include(c => c.ComicCharacters).ThenInclude(c => c.Character).Include(c => c.Category).
                Where(c=>c.IsActive == true).OrderByDescending(c=>c.SaleQuantity).Take(3).ToList(),
                Characters = _context.Characters.Include(c=>c.City).Include(c => c.Categories).Include(c => c.CharacterPowers).ThenInclude(c => c.Power).
                Include(c => c.ComicCharacters).ThenInclude(cc => cc.Comic).Include(c => c.TeamCharacters).ThenInclude(tc => tc.Team).
                Include(c => c.ToyCharacters).ThenInclude(tc => tc.Toy).Where(c => c.IsActive == true).ToList(),
                FilteringComics = _context.Comics.Include(c => c.ComicCharacters).ThenInclude(c => c.Character).Include(c => c.Category).
                Where(c=>c.CreatedDate >= DateTime.Now.AddDays(-7) && c.IsActive == true).ToList(),
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

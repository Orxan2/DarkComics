using DarkComics.DAL;
using DarkComics.Models.Entity;
using DarkComics.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkComics.Controllers
{
    public class NewsController : Controller
    {
        private readonly DarkComicDbContext _context;
        public NewsController(DarkComicDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            NewsViewModel newsViewModel = new NewsViewModel
            {
                NewsList = _context.News.Include(n => n.CharacterNews).ThenInclude(cn => cn.Character).Include(n => n.TagNews).
             ThenInclude(tn => tn.Tag).ToList()
            };

            return View(newsViewModel);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            News news = _context.News.Include(n => n.CharacterNews).ThenInclude(cn => cn.Character).Include(n => n.TagNews).
                ThenInclude(tn => tn.Tag).FirstOrDefault(n=>n.Id == id);

            if (news == null)
            {
                return NotFound();
            }

            NewsViewModel newsViewModel = new NewsViewModel
            {
                News = news
            };
            return View(newsViewModel);
        }

    }
}

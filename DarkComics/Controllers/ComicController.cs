﻿using DarkComics.DAL;
using DarkComics.Helpers.Enums;
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

            ComicViewModel comicViewModel = new ComicViewModel
            {
               Series = _context.Series.Include(p => p.ComicDetails).ThenInclude(cd => cd.Products).ThenInclude(p => p.ProductCharacters).
               ThenInclude(pc => pc.Character).Where(s=>s.IsDeleted == false).ToList(),
                RandomComics = _context.Products.Include(p => p.ComicDetail).ThenInclude(cd => cd.Serie).Include(p => p.ProductCharacters).
               ThenInclude(pc => pc.Character).Where(p => p.Category == Category.Comic && p.ComicDetail.IsCover == true && p.IsActive == true).ToList()
            };

            int count = comicViewModel.Series.Count();

            HttpContext.Response.Cookies.Append("ComicQuantity", count.ToString());

            return View(comicViewModel);
        }

        public IActionResult LoadMore(int skip, int take)
        {
            ComicViewModel comicViewModel = new ComicViewModel
            {
                Series = _context.Series.Include(p => p.ComicDetails).ThenInclude(cd => cd.Products).ThenInclude(p => p.ProductCharacters).
               ThenInclude(pc => pc.Character).OrderBy(s => s.Id).Skip(skip).Take(take).ToList()
            };


            return View("_LoadMore", comicViewModel);
        }

        public IActionResult Search(string search)
        {
            ComicViewModel comicViewModel = new ComicViewModel
            {
                Series = _context.Series.Include(p => p.ComicDetails).ThenInclude(cd => cd.Products).ThenInclude(p => p.ProductCharacters).
               ThenInclude(pc => pc.Character).OrderBy(c => c.Id).Where(s=>s.Name.Contains(search)).ToList()
            };

            return View("_LoadMore", comicViewModel);
        }
    }
}

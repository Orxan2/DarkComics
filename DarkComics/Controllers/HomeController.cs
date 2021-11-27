﻿using DarkComics.DAL;
using DarkComics.Helpers.Enums;
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
                
                Comics = _context.Products.Include(c => c.ComicDetail).ThenInclude(c => c.Serie).Include(c => c.ProductCharacters).
                ThenInclude(pc=>pc.Character).Where(c => c.IsActive == true && c.Category == Category.Comic).ToList(),
                BestComics = _context.Products.Include(c => c.ComicDetail).ThenInclude(c => c.Serie).Include(c => c.ProductCharacters).
                ThenInclude(pc => pc.Character).Where(c => c.IsActive == true && c.Category == Category.Comic).OrderByDescending(c => c.Quantity).Take(3).ToList(),
                Characters = _context.Characters.Include(c => c.City).Include(c => c.ProductCharacters).ThenInclude(c => c.Product).ThenInclude(p => p.ComicDetail).
                Include(c => c.CharacterPowers).ThenInclude(cp => cp.Power).Include(c => c.ToyCharacters).ThenInclude(tc => tc.Toy).
                Include(c => c.ToyCharacters).ThenInclude(tc => tc.Toy).Include(c => c.CharacterNews).ThenInclude(cn => cn.News).Where(c => c.IsActive == true).ToList(),
                FilteringComics = _context.Products.Include(c => c.ComicDetail).ThenInclude(c => c.Serie).Include(c => c.ProductCharacters).
                ThenInclude(pc => pc.Character).Where(c => c.IsActive == true && c.Category == Category.Comic && c.CreatedDate >= DateTime.Now.AddDays(-7)).ToList(),
                Series = _context.Series.Include(p => p.ComicDetails).ThenInclude(cd => cd.Products).ThenInclude(p => p.ProductCharacters).
               ThenInclude(pc => pc.Character).Where(s => s.IsDeleted == false).ToList()
            };

            return View(homeViewModel);
        }
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product comic = _context.Products.Include(c => c.ComicDetail).ThenInclude(c => c.Serie).Include(c => c.ProductCharacters).
                ThenInclude(pc => pc.Character).Where(c => c.IsActive == true && c.Category == Category.Comic).FirstOrDefault(c => c.Id == id);

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

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Contact(FooterViewModel footerViewModel)
        {
            if (!ModelState.IsValid)
                return View(footerViewModel);

            //footerViewModel.Contact.CreatedDate = DateTime.UtcNow.AddHours(4);
            _context.Contact.Add(footerViewModel.Contact);
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }
    }
    }

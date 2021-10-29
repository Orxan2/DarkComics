using DarkComics.DAL;
using DarkComics.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkComics.Controllers
{
    public class CharacterController : Controller
    {
        private readonly DarkComicDbContext _context;
        public CharacterController(DarkComicDbContext context)
        {
            _context = context;
        }
        // GET: CharacterController
        public ActionResult Index()
        {
            CharacterViewModel characterViewModel = new CharacterViewModel
            {
                Characters = _context.Characters.Include(c => c.Categories).ThenInclude(c => c.Comics).Include(c => c.CharacterPowers).ThenInclude(cp => cp.Power).
                Include(c => c.TeamCharacters).ThenInclude(tc => tc.Team).Include(c => c.ToyCharacters).ThenInclude(tc => tc.Toy).ToList()
            };

            return View(characterViewModel);
        }

        // GET: CharacterController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CharacterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CharacterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CharacterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CharacterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CharacterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CharacterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

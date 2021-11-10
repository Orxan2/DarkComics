using DarkComics.DAL;
using DarkComics.ViewComponents;
using DarkComics.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkComics.Controllers
{
    public class SearchController : Controller
    {
        private readonly DarkComicDbContext _context;
        public SearchController(DarkComicDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        [AutoValidateAntiforgeryTokenAttribute]
        public IActionResult Search(SearchViewModel searchViewModel)
        {
            if (string.IsNullOrEmpty(searchViewModel.Name))
            {
                return NotFound();
            }

            SearchViewModel search = new SearchViewModel
            {
                Products = _context.Products.Include(p => p.ComicDetail).ThenInclude(cd => cd.Serie).Include(p => p.ProductCharacters).
              ThenInclude(pc => pc.Character).Where(p => p.IsActive == true && p.Name.ToLower().Contains(searchViewModel.Name.ToLower())).ToList()
            };
            return View(search);
        }
    }
}

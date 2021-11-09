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
               Series = _context.Series.Include(p => p.ComicDetails).ThenInclude(cd => cd.Products).ThenInclude(p => p.ProductCharacters).
               ThenInclude(pc => pc.Character).Where(s=>s.IsDeleted == false).ToList(),
                RandomComics = _context.Products.Include(p => p.ComicDetail).ThenInclude(cd => cd.Serie).Include(p => p.ProductCharacters).
               ThenInclude(pc => pc.Character).Where(p => p.Category == Category.Comic && p.ComicDetail.IsCover == true && p.IsActive == true).ToList()
            };

            int count = comicViewModel.Series.Count();

            HttpContext.Response.Cookies.Append("ComicQuantity", count.ToString());

            return View(comicViewModel);
        }
        public IActionResult AddBasket(int id)
        {
            var dbProduct = _context.Products.ToList().FirstOrDefault(b => b.Id == id && b.IsActive == true);
            if (dbProduct == null)
            {
                return NotFound();
            }

            List<BasketProduct> temporaryList = new List<BasketProduct>();
            var myCookie = Request.Cookies["basket"];
            temporaryList = BasketMethod.AddBasket(dbProduct,myCookie);
            myCookie = JsonSerializer.Serialize(temporaryList);
            Response.Cookies.Append("basket", myCookie);
            
           
            // Show Cookie

            List<Product> products = _context.Products.Include(p => p.ComicDetail).ThenInclude(cd => cd.Serie).Include(p => p.ProductCharacters).
               ThenInclude(pc => pc.Character).Where(p => p.IsActive == true).ToList();
            BasketViewModel basketView = BasketMethod.ShowBasket(products,myCookie);         
           
            return View("_Basket", basketView);

        }

        public IActionResult DeleteProduct(int id)
        {
            var dbProduct = _context.Products.ToList().FirstOrDefault(b => b.Id == id && b.IsActive == true);
            if (dbProduct == null)
            {
                return NotFound();
            }
            string cookie = Request.Cookies["basket"];
            var temporaryList = JsonSerializer.Deserialize<List<BasketProduct>>(cookie);
            var product = temporaryList.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                temporaryList.Remove(product);
            }
           
            Response.Cookies.Append("basket", JsonSerializer.Serialize<List<BasketProduct>>(temporaryList));

            List<Product> products = _context.Products.Include(p => p.ComicDetail).ThenInclude(cd => cd.Serie).Include(p => p.ProductCharacters).
             ThenInclude(pc => pc.Character).Where(p => p.IsActive == true).ToList();
            cookie = JsonSerializer.Serialize(temporaryList);
            BasketViewModel basketView = BasketMethod.ShowBasket(products, cookie);

            return View("_Basket", basketView);

        }

        public IActionResult DecreaseProduct(int id)
        {
            var dbProduct = _context.Products.ToList().FirstOrDefault(b => b.Id == id && b.IsActive == true);
            if (dbProduct == null)
            {
                return NotFound();
            }
            var cookie = Request.Cookies["basket"];
            var temporaryList = new List<BasketProduct>();

            if (!string.IsNullOrEmpty(cookie))
            {
                temporaryList = JsonSerializer.Deserialize<List<BasketProduct>>(cookie);
                if (temporaryList != null)
                {
                    var product = temporaryList.FirstOrDefault(p => p.Id == id);
                    if (product != null && product.Count > 0)
                    {
                        product.Count--;
                        Response.Cookies.Append("basket", JsonSerializer.Serialize(temporaryList));                        
                    }
                }

            }
            cookie = JsonSerializer.Serialize(temporaryList);
            List<Product> products = _context.Products.Include(p => p.ComicDetail).ThenInclude(cd => cd.Serie).Include(p => p.ProductCharacters).
              ThenInclude(pc => pc.Character).Where(p => p.IsActive == true).ToList();
            BasketViewModel basketView = BasketMethod.ShowBasket(products, cookie);

            return View("_Basket",basketView);

        }

        public IActionResult IncreaseProduct(int id)
        {
            var dbProduct = _context.Products.ToList().FirstOrDefault(b => b.Id == id && b.IsActive == true);
            if (dbProduct == null)
            {
                return NotFound();
            }
            var cookie = Request.Cookies["basket"];
            var temporaryList = new List<BasketProduct>();

            if (!string.IsNullOrEmpty(cookie))
            {
                temporaryList = JsonSerializer.Deserialize<List<BasketProduct>>(cookie);
                if (temporaryList != null)
                {
                    var product = temporaryList.FirstOrDefault(p => p.Id == id);
                    if (product != null)
                    {
                        product.Count++;
                        Response.Cookies.Append("basket", JsonSerializer.Serialize(temporaryList));
                    }
                }

            }
            cookie = JsonSerializer.Serialize(temporaryList);
            List<Product> products = _context.Products.Include(p => p.ComicDetail).ThenInclude(cd => cd.Serie).Include(p => p.ProductCharacters).
              ThenInclude(pc => pc.Character).Where(p => p.IsActive == true).ToList();
            BasketViewModel basketView = BasketMethod.ShowBasket(products, cookie);

            return View("_Basket", basketView);

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

using DarkComics.DAL;
using DarkComics.Helpers.Methods;
using DarkComics.Models.Entity;
using DarkComics.ViewModels.Basket;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DarkComics.Controllers
{
    public class BasketController : Controller
    {
        private readonly DarkComicDbContext _context;
        public BasketController(DarkComicDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var cookie = HttpContext.Request.Cookies["basket"];
            var temporaryList = JsonSerializer.Deserialize<List<BasketProduct>>(cookie);
            List<Product> products = _context.Products.Include(p => p.ComicDetail).ThenInclude(cd => cd.Serie).Include(p => p.ProductCharacters).
             ThenInclude(pc => pc.Character).Where(p => p.IsActive == true).ToList();
            BasketViewModel basketView = BasketMethod.ShowBasket(products, cookie);



            return View(basketView);
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
            temporaryList = BasketMethod.AddBasket(dbProduct, myCookie);
            myCookie = JsonSerializer.Serialize(temporaryList);
            Response.Cookies.Append("basket", myCookie);


            // Show Cookie

            List<Product> products = _context.Products.Include(p => p.ComicDetail).ThenInclude(cd => cd.Serie).Include(p => p.ProductCharacters).
               ThenInclude(pc => pc.Character).Where(p => p.IsActive == true).ToList();
            BasketViewModel basketView = BasketMethod.ShowBasket(products, myCookie);

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

            return View("_Basket", basketView);

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
    }
}

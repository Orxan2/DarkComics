using DarkComics.DAL;
using DarkComics.Helpers.Enums;
using DarkComics.Models.Entity;
using DarkComics.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DarkComics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ComicController : Controller
    {
        private readonly DarkComicDbContext _db;
        private readonly IWebHostEnvironment _env;
        public ComicController(DarkComicDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        // GET: ComicController
        public ActionResult Index()
        {
            ComicViewModel comicViewModel = new ComicViewModel
            {
                Series = _db.Series.Include(p => p.ComicDetails).ThenInclude(cd => cd.Products).ThenInclude(p => p.ProductCharacters).
               ThenInclude(pc => pc.Character).Where(s => s.IsDeleted == false).ToList()
            };

            return View(comicViewModel);
        }

        // GET: ComicController/Details/5
        public ActionResult ComicIndex(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            List<Product> products = _db.Products.Include(p => p.ComicDetail).ThenInclude(cd => cd.Serie).Include(p => p.ProductCharacters).
               ThenInclude(pc => pc.Character).Where(p => p.Category == Category.Comic && p.ComicDetail.SerieId == id).ToList();
                        
            ComicViewModel comicView = new ComicViewModel
            {
                RandomComics = products
            };

            return View(comicView);
        }

        public ActionResult CreateSerie()
        {
            ComicViewModel comicViewModel = new ComicViewModel
            {               
                CharacterList = new List<SelectListItem>(),
                TeamOrNot = new List<SelectListItem>(),
                Characters = _db.Characters.ToList()

            };


            foreach (var character in comicViewModel.Characters)
            {
                comicViewModel.CharacterList.AddRange(new List<SelectListItem>{
                    new SelectListItem() { Text = character.Name, Value = character.Id.ToString() }
                });
            }
          

            return View(comicViewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public ActionResult CreateSerie(ComicViewModel comicViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(comicViewModel);
            }

            comicViewModel.Serie.Cover = RenderSerieImage(comicViewModel, comicViewModel.Serie.CoverPhoto);
            comicViewModel.Serie.Backface = RenderSerieImage(comicViewModel, comicViewModel.Serie.BackfacePhoto);


            if (string.IsNullOrEmpty(comicViewModel.Serie.Cover) || string.IsNullOrEmpty(comicViewModel.Serie.Backface))
            {
                ModelState.AddModelError("Image", "Image was incorrect");
                return View(comicViewModel);
            }

            _db.Series.Add(comicViewModel.Serie);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public ActionResult CreateComic(int? id)
        {
           
            ComicViewModel comicViewModel = new ComicViewModel
            {
                Serie = _db.Series.Include(p => p.ComicDetails).ThenInclude(cd => cd.Products).ThenInclude(p => p.ProductCharacters).
                ThenInclude(pc => pc.Character).Where(s => s.IsDeleted == false).FirstOrDefault(s => s.Id == id),
                CharacterList = new List<SelectListItem>(),
                Characters = _db.Characters.ToList()

        };

           
            foreach (var character in comicViewModel.Characters)
            {
                comicViewModel.CharacterList.AddRange(new List<SelectListItem>{
                    new SelectListItem() { Text = character.Name, Value = character.Id.ToString() }
                });
            }
            return View(comicViewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public ActionResult CreateComic(int? id, ComicViewModel comicView)
        {
            if (id == null)
            {
                return NotFound();
            }
            Serie serie = _db.Series.FirstOrDefault(s => s.Id == id);

            if (serie == null)
            {
                return NotFound();
            }

            comicView.Comic.Category = Category.Comic;           
            comicView.Comic.ComicDetail.Serie = serie;
            comicView.Comic.ComicDetail.IsCover = true;


            if (!ModelState.IsValid)
            {
                return View(comicView);
            }
            comicView.Comic.Image = RenderImage(comicView, comicView.Comic.Photo);           
            comicView.Comic.ComicDetail.Backface = RenderImage(comicView, comicView.Comic.ComicDetail.BackfacePhoto);

            if (string.IsNullOrEmpty(comicView.Comic.Image))
            {
                ModelState.AddModelError("Image", "Image was incorrect");
                return View(comicView);
            }
           
            _db.Products.Add(comicView.Comic);
            _db.SaveChanges();

            // Create ProductCharacter
            int? productId = _db.Products.Max(c => c.Id);
            Product product = _db.Products.Find(productId);

            foreach (var chosencharacter in comicView.ChosenCharacters)
            {
                Character character = _db.Characters.FirstOrDefault(p => p.Id == chosencharacter);
                ProductCharacter productCharacter = new ProductCharacter();

                productCharacter.ProductId = productId;
                productCharacter.CharacterId = character.Id;
                _db.ProductCharacters.Add(productCharacter);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: ComicController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ComicController/Edit/5
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

        public ActionResult MakeActiveOrDeactive(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = _db.Products.Include(p => p.ComicDetail).ThenInclude(cd => cd.Serie).Include(p => p.ProductCharacters).
               ThenInclude(pc => pc.Character).Where(p => p.Category == Category.Comic).ToList().FirstOrDefault(c => c.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            if (product.IsActive == true)
                product.IsActive = false;
            else
                product.IsActive = true;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        public string RenderImage(ComicViewModel comicVM, IFormFile photo)
        {
            if (!photo.ContentType.Contains("image"))
            {
                return null;
            }
            if (photo.Length / 1024 > 10000)
            {
                return null;
            }

            string filename = Guid.NewGuid().ToString() + '-' + photo.FileName;
            string environment = _env.WebRootPath;
            string newSlider = Path.Combine(environment, "assets", "img","comics", comicVM.Comic.ComicDetail.Serie.Name.Replace(" ", "-").ToLower(),comicVM.Comic.ComicDetail.Id.ToString());

            if (!Directory.Exists(newSlider))
            {
                Directory.CreateDirectory(newSlider);
            }
            newSlider = Path.Combine(newSlider, filename);

            using (FileStream file = new FileStream(newSlider, FileMode.Create))
            {
                photo.CopyTo(file);
            }

            return filename;

        }
        public string RenderSerieImage(ComicViewModel comicVM, IFormFile photo)
        {
            if (!photo.ContentType.Contains("image"))
            {
                return null;
            }
            if (photo.Length / 1024 > 10000)
            {
                return null;
            }

            string filename = Guid.NewGuid().ToString() + '-' + photo.FileName;
            string environment = _env.WebRootPath;
            string newSlider = Path.Combine(environment, "assets", "img", "comics", comicVM.Serie.Name.Replace(" ", "-").ToLower());

            if (!Directory.Exists(newSlider))
            {
                Directory.CreateDirectory(newSlider);
            }
            newSlider = Path.Combine(newSlider, filename);

            using (FileStream file = new FileStream(newSlider, FileMode.Create))
            {
                photo.CopyTo(file);
            }

            return filename;

        }
    }
}

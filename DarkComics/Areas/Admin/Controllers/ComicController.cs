using DarkComics.DAL;
using DarkComics.Helpers.Enums;
using DarkComics.Models.Entity;
using DarkComics.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        // GET: EventController/Edit/5
        public IActionResult UpdateSerie(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Serie serie = _db.Series.Include(s => s.ComicDetails).ThenInclude(cd => cd.Products).FirstOrDefault(s => s.Id == id);
            if (serie == null)
            {
                return NotFound();
            }

            ComicViewModel comicViewModel = new ComicViewModel
            {
               Serie = serie
            };
            comicViewModel.Cover = comicViewModel.Serie.Cover;
            comicViewModel.Backface = comicViewModel.Serie.Backface;

            return View(comicViewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult UpdateSerie(int? id, ComicViewModel comicViewModel)
        {
            if (id == null || (id != comicViewModel.Serie.Id))
            {
                return NotFound();
            }


            //if user don't choose image program enter here
            if (comicViewModel.Serie.CoverPhoto == null)
            {
                comicViewModel.Serie.Cover = comicViewModel.Cover;
                ModelState["Serie.CoverPhoto"].ValidationState = ModelValidationState.Valid;
            }
            else
                comicViewModel.Serie.Cover = RenderSerieImage(comicViewModel, comicViewModel.Serie.CoverPhoto, comicViewModel.Cover);

            if (comicViewModel.Serie.BackfacePhoto == null)
            {
                comicViewModel.Serie.Backface = comicViewModel.Backface;
                ModelState["Serie.BackfacePhoto"].ValidationState = ModelValidationState.Valid;
            }
            else
                comicViewModel.Serie.Backface = RenderSerieImage(comicViewModel, comicViewModel.Serie.BackfacePhoto, comicViewModel.Backface);
                     
            if (string.IsNullOrEmpty(comicViewModel.Serie.Cover) || string.IsNullOrEmpty(comicViewModel.Serie.Backface))
            {
                ModelState.AddModelError("Image", "Image was incorrect");
                return View(comicViewModel);
            }

            if (!ModelState.IsValid)
                return View(comicViewModel.Serie);


            _db.Series.Update(comicViewModel.Serie);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

        // GET: EventController/Edit/5
        public IActionResult UpdateComic(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           ComicViewModel comicViewModel = new ComicViewModel
            {
                Comic = _db.Products.Include(p => p.ComicDetail).ThenInclude(cd => cd.Serie).Include(p => p.ProductCharacters).
                ThenInclude(pc => pc.Character).Where(p => p.Category == Category.Comic && p.IsActive == true).FirstOrDefault(c=>c.Id == id),
               CharacterList = new List<SelectListItem>(),
               Characters = _db.Characters.ToList(),
               Series = _db.Series.Include(p => p.ComicDetails).ThenInclude(cd => cd.Products).ThenInclude(p => p.ProductCharacters).
               ThenInclude(pc => pc.Character).Where(s => s.IsDeleted == false).ToList(),
               SerieList = new List<SelectListItem>()

           };
            comicViewModel.Cover = comicViewModel.Comic.Image;
            comicViewModel.Backface = comicViewModel.Comic.ComicDetail.Backface;
           
            if (comicViewModel.Comic == null)
            {
                return BadRequest();
            }

            foreach (var character in comicViewModel.Characters)
            {
                comicViewModel.CharacterList.AddRange(new List<SelectListItem>{
                    new SelectListItem() { Text = character.Name, Value = character.Id.ToString() }
                });
            }

            foreach (var serie in comicViewModel.Series)
            {
                comicViewModel.SerieList.AddRange(new List<SelectListItem>{
                    new SelectListItem() { Text = serie.Name, Value = serie.Id.ToString() }
                });
            }
            return View(comicViewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult UpdateComic(int? id, ComicViewModel comicViewModel)
         {
            if (id == null || comicViewModel.Comic.Id != id)
            {
                return NotFound();
            }

            

            //if user don't choose image program enter here
            if (comicViewModel.Comic.Photo == null)
            {
                comicViewModel.Comic.Image = comicViewModel.Cover;
                ModelState["Comic.Photo"].ValidationState = ModelValidationState.Valid;
            }
            else
                comicViewModel.Comic.Image = RenderImage(comicViewModel, comicViewModel.Comic.Photo, comicViewModel.Cover);

            if (comicViewModel.Comic.ComicDetail.BackfacePhoto == null)
            {
                comicViewModel.Comic.ComicDetail.Backface = comicViewModel.Backface;
                ModelState["Comic.ComicDetail.Backface"].ValidationState = ModelValidationState.Valid;
            }
            else
                comicViewModel.Comic.ComicDetail.Backface = RenderImage(comicViewModel, comicViewModel.Comic.ComicDetail.BackfacePhoto, comicViewModel.Backface);
                      
            if (string.IsNullOrEmpty(comicViewModel.Comic.ComicDetail.Backface) || string.IsNullOrEmpty(comicViewModel.Comic.Image))
            {
                ModelState.AddModelError("Image", "Image was incorrect");
                return View(comicViewModel);
            }

            if (!ModelState.IsValid)
                return View(comicViewModel);

            comicViewModel.Comic.ComicDetailId = comicViewModel.Comic.ComicDetail.Id;
            comicViewModel.Comic.IsActive = true;
            comicViewModel.Comic.Category = Category.Comic;

            //_db.ComicDetails.Update(comicViewModel.Comic.ComicDetail);
            _db.Products.Update(comicViewModel.Comic);

            _db.SaveChanges();

            // Create ProductCharacter
            int? productId = comicViewModel.Comic.Id;
            Product product = _db.Products.Find(productId);

            foreach (var chosencharacter in comicViewModel.ChosenCharacters)
            {
                Character characterDb = _db.Characters.FirstOrDefault(p => p.Id == chosencharacter);
                ProductCharacter productCharacter = _db.ProductCharacters.FirstOrDefault(pc => pc.ProductId == productId && pc.CharacterId == characterDb.Id);
                if (productCharacter == null)
                {
                    productCharacter = new ProductCharacter();
                    productCharacter.CharacterId = characterDb.Id;
                    productCharacter.ProductId = productId;
                    _db.ProductCharacters.Add(productCharacter);
                }
                else
                {
                    productCharacter.CharacterId = characterDb.Id;
                    productCharacter.ProductId = productId;
                    _db.ProductCharacters.Update(productCharacter);
                }
                _db.SaveChanges();
 }
                return RedirectToAction(nameof(Index), comicViewModel);
           
        }
        
        public ActionResult MakeActiveOrDeactive(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = _db.Products.Include(p => p.ComicDetail).ThenInclude(cd => cd.Serie).Include(p => p.ProductCharacters).
               ThenInclude(pc => pc.Character).Where(p => p.Category == Category.Comic).FirstOrDefault(c => c.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            if (product.IsActive == true)
                product.IsActive = false;
            else
                product.IsActive = true;

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
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
            string newSlider = Path.Combine(environment, "assets", "img", $"product-{comicVM.Comic.Id}");
            if (comicVM.Comic.Id == null)
              newSlider = Path.Combine(environment, "assets", "img",  $"product-{_db.Products.Max(c => c.Id + 1)}");


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
        public string RenderImage(ComicViewModel comicVM, IFormFile photo, string oldFilename)
        {
            oldFilename = Path.Combine(_env.WebRootPath, "assets", "img", $"product-{comicVM.Comic.Id}", oldFilename);
            FileInfo oldFile = new FileInfo(oldFilename);
            if (System.IO.File.Exists(oldFilename))
            {
                oldFile.Delete();
            };

            return RenderImage(comicVM, photo);
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
            string newSlider = Path.Combine(environment, "assets", "img", "comics", $"serie-{comicVM.Serie.Id}");
            if (comicVM.Serie.Id == null)
              newSlider = Path.Combine(environment, "assets", "img", "comics", $"serie-{_db.Series.Max(c => c.Id + 1)}");

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

        public string RenderSerieImage(ComicViewModel comicVM, IFormFile photo, string oldFilename)
        {
            oldFilename = Path.Combine(_env.WebRootPath,"assets","img","comics", $"serie-{comicVM.Serie.Id}",oldFilename);
            FileInfo oldFile = new FileInfo(oldFilename);
            if (System.IO.File.Exists(oldFilename))
            {
                oldFile.Delete();
            };

            return RenderSerieImage(comicVM, photo);
        }

    }
}

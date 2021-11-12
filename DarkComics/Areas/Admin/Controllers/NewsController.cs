using DarkComics.DAL;
using DarkComics.Models.Entity;
using DarkComics.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DarkComics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : Controller
    {
        private readonly DarkComicDbContext _db;
        private readonly IWebHostEnvironment _env;
        public NewsController(DarkComicDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            NewsViewModel newsViewModel = new NewsViewModel
            {
                NewsList = _db.News.Include(n => n.CharacterNews).ThenInclude(cn => cn.Character).Include(n => n.TagNews).ThenInclude(tn => tn.Tag).ToList(),
                
            };
            return View(newsViewModel);
        }

        public ActionResult Create()
        {

            NewsViewModel newsViewModel = new NewsViewModel
            {
                NewsList = _db.News.Include(n => n.CharacterNews).ThenInclude(cn => cn.Character).Include(n => n.TagNews).ThenInclude(tn => tn.Tag).ToList(),
                Tags = _db.Tags.ToList(),
                TagList = new List<SelectListItem>(),
                Characters = _db.Characters.ToList(),
                CharacterList = new List<SelectListItem>()
            };

            foreach (var tag in newsViewModel.Tags)
            {
                newsViewModel.TagList.AddRange(new List<SelectListItem>{
                    new SelectListItem() { Text = tag.Title, Value = tag.Id.ToString() }
                });
            }

            foreach (var character in newsViewModel.Characters)
            {
                newsViewModel.CharacterList.AddRange(new List<SelectListItem>{
                    new SelectListItem() { Text = character.Name, Value = character.Id.ToString() }
                });
            }


            return View(newsViewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public ActionResult Create(NewsViewModel newsViewModel)
        {

            if (!ModelState.IsValid)
            {
                return View(newsViewModel);
            }

            newsViewModel.News.Image = RenderImage(newsViewModel.News, newsViewModel.News.Photo);           

            if (string.IsNullOrEmpty(newsViewModel.News.Image))
            {
                ModelState.AddModelError("Image", "Image was incorrect");
                return View(newsViewModel);
            }

            _db.News.Add(newsViewModel.News);
            _db.SaveChanges();

            int? newsId = _db.News.Max(n => n.Id);
            News News = _db.News.Find(newsId);

            foreach (var character in newsViewModel.ChosenCharacters)
            {
                Character characterDb = _db.Characters.FirstOrDefault(p => p.Id == character);
                CharacterNews characterNews = new CharacterNews();

                characterNews.NewsId = newsId;
                characterNews.CharacterId = characterDb.Id;
                _db.CharacterNews.Add(characterNews);
                _db.SaveChanges();
            }

            foreach (var chosenTag in newsViewModel.ChosenTags)
            {
                Tag tag = _db.Tags.FirstOrDefault(t => t.Id == chosenTag);
                TagNews tagNews = new TagNews();

                tagNews.NewsId = newsId;
                tagNews.TagId = tag.Id;
                _db.TagNews.Add(tagNews);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", newsViewModel);
        }

        public string RenderImage(News news, IFormFile photo)
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
            string newSlider = Path.Combine(environment, "assets", "img","news", $"news-{news.Id}");
            if (news.Id == null)
                newSlider = Path.Combine(environment, "assets", "img", "news", $"news-{_db.Characters.Max(c => c.Id + 1)}");



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

        public string RenderImage(News news, IFormFile photo, string oldFilename)
        {
            oldFilename = Path.Combine(_env.WebRootPath, "assets", "img", "news", $"news-{news.Id}", oldFilename);
            FileInfo oldFile = new FileInfo(oldFilename);
            if (System.IO.File.Exists(oldFilename))
            {
                oldFile.Delete();
            };

            return RenderImage(news, photo);
        }
    }
}

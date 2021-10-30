using DarkComics.DAL;
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
using System.Reflection;
using System.Threading.Tasks;

namespace DarkComics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CharacterController : Controller
    {
        private readonly DarkComicDbContext _db;
        private readonly IWebHostEnvironment _env;
        public CharacterController(DarkComicDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public ActionResult Index()
        {
            CharacterViewModel characterViewModel = new CharacterViewModel
            {
                Characters = _db.Characters.Include(c => c.Categories).ThenInclude(c => c.Comics).Include(c => c.CharacterPowers).ThenInclude(cp => cp.Power).
                Include(c => c.TeamCharacters).ThenInclude(tc => tc.Team).Include(c => c.ToyCharacters).ThenInclude(tc => tc.Toy).ToList()
            };

            return View(characterViewModel);
        }

        
        public ActionResult Create()
        {
            CharacterViewModel characterViewModel = new CharacterViewModel
            {
                Powers = _db.Powers.ToList(),
                PowerList = new List<SelectListItem>(),
                Characters = _db.Characters.Include(c => c.Categories).ThenInclude(c => c.Comics).Include(c => c.CharacterPowers).ThenInclude(cp => cp.Power).
                Include(c => c.TeamCharacters).ThenInclude(tc => tc.Team).Include(c => c.ToyCharacters).ThenInclude(tc => tc.Toy).ToList()

            };
            //characterViewModel.Powers = new List<SelectListItem>() { };
            foreach (var power in characterViewModel.Powers)
            {
                characterViewModel.PowerList.AddRange(new List<SelectListItem>{
                    new SelectListItem() { Text = power.Name, Value = power.Id.ToString() } });
                ;
                //new SelectListItem() { Text = characterPower.Power.Name, Value = characterPower.Power.Id.ToString() };
            }

            return View(characterViewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public ActionResult Create(CharacterViewModel characterVM)
        {
            if (!ModelState.IsValid)
            {
                return View(characterVM);
            }

            characterVM.Character.Logo = RenderImage(characterVM.Character, characterVM.Character.LogoPhoto);
            characterVM.Character.FirstImage = RenderImage(characterVM.Character, characterVM.Character.FirstPhoto);
            characterVM.Character.SecondImage = RenderImage(characterVM.Character, characterVM.Character.SecondPhoto);
            characterVM.Character.Profile = RenderImage(characterVM.Character, characterVM.Character.ProfilePhoto);

            if (string.IsNullOrEmpty(characterVM.Character.Logo) || string.IsNullOrEmpty(characterVM.Character.FirstImage) ||
                string.IsNullOrEmpty(characterVM.Character.SecondImage) || string.IsNullOrEmpty(characterVM.Character.Profile))
            {
                ModelState.AddModelError("Image","Image was incorrect");
                return View(characterVM);
            }
           

            _db.Characters.Add(characterVM.Character);
            _db.SaveChanges();

            int? characterId = _db.Characters.Max(c => c.Id);
            Character character = _db.Characters.Find(characterId);


            //_db.Characters.Add(characterVM.Character);
            foreach (var power in characterVM.ChosenPowers)
            {
                Power pow = _db.Powers.FirstOrDefault(p => p.Id == power);
                CharacterPower characterPower = new CharacterPower();


                //characterPower.Id = _db.CharacterPowers.Max(c => c.Id)+1;
                characterPower.CharacterId = characterId;
                characterPower.PowerId = pow.Id;
                _db.CharacterPowers.Add(characterPower);
                _db.SaveChanges();
            }

            //characterVM.Characters = _db.Characters.Include(c => c.Categories).ThenInclude(c => c.Comics).Include(c => c.CharacterPowers).ThenInclude(cp => cp.Power).
            //     Include(c => c.TeamCharacters).ThenInclude(tc => tc.Team).Include(c => c.ToyCharacters).ThenInclude(tc => tc.Toy).ToList();
            
                return RedirectToAction("Index", characterVM);
        }

        public ActionResult MakeActiveOrDeactive(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Character character = _db.Characters.Include(c => c.Categories).ThenInclude(c => c.Comics).Include(c => c.CharacterPowers).ThenInclude(cp => cp.Power).
                  Include(c => c.TeamCharacters).ThenInclude(tc => tc.Team).Include(c => c.ToyCharacters).ThenInclude(tc => tc.Toy).FirstOrDefault(c=>c.Id == id);

            if (character == null)
            {
                return NotFound();
            }

            if (character.IsActive == true)
                character.IsActive = false;
            else
                character.IsActive = true;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        public string RenderImage(Character character,IFormFile photo)
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
            string newSlider = Path.Combine(environment, "assets", "img", character.HeroName.Replace(" ", "-").ToLower());

            if (!Directory.Exists(newSlider))
            {
                Directory.CreateDirectory(newSlider);
            }
            newSlider = Path.Combine(newSlider,filename);

            using (FileStream file = new FileStream(newSlider, FileMode.Create))
            {
                photo.CopyTo(file);
            }           
           
            return filename;

        }
    }
}

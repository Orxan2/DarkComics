using DarkComics.DAL;
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
                Characters = _db.Characters.Include(c => c.City).Include(c => c.Categories).ThenInclude(c => c.Comics).Include(c => c.CharacterPowers).ThenInclude(cp => cp.Power).
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
                CitiesList = new List<SelectListItem>(),
                Characters = _db.Characters.Include(c => c.City).Include(c => c.Categories).ThenInclude(c => c.Comics).Include(c => c.CharacterPowers).ThenInclude(cp => cp.Power).
                Include(c => c.TeamCharacters).ThenInclude(tc => tc.Team).Include(c => c.ToyCharacters).ThenInclude(tc => tc.Toy).ToList(),
                Cities = _db.Cities.ToList()

            };
            foreach (var power in characterViewModel.Powers)
            {
                characterViewModel.PowerList.AddRange(new List<SelectListItem>{
                    new SelectListItem() { Text = power.Name, Value = power.Id.ToString() }
                });
            }

            foreach (var city in characterViewModel.Cities)
            {
                characterViewModel.CitiesList.AddRange(new List<SelectListItem>{
                    new SelectListItem() { Text = city.Name, Value = city.Id.ToString() }
                });
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
            characterVM.Character.LayoutImage = RenderImage(characterVM.Character, characterVM.Character.LayoutPhoto);

            if (string.IsNullOrEmpty(characterVM.Character.Logo) || string.IsNullOrEmpty(characterVM.Character.FirstImage) ||
                string.IsNullOrEmpty(characterVM.Character.SecondImage) || string.IsNullOrEmpty(characterVM.Character.Profile) ||
                string.IsNullOrEmpty(characterVM.Character.LayoutImage))
            {
                ModelState.AddModelError("Image", "Image was incorrect");
                return View(characterVM);
            }

            _db.Characters.Add(characterVM.Character);
            _db.SaveChanges();

            int? characterId = _db.Characters.Max(c => c.Id);
            Character character = _db.Characters.Find(characterId);

            foreach (var power in characterVM.ChosenPowers)
            {
                Power pow = _db.Powers.FirstOrDefault(p => p.Id == power);
                CharacterPower characterPower = new CharacterPower();

                characterPower.CharacterId = characterId;
                characterPower.PowerId = pow.Id;
                _db.CharacterPowers.Add(characterPower);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", characterVM);
        }

        // GET: EventController/Edit/5
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CharacterViewModel characterViewModel = new CharacterViewModel
            {
               Character = _db.Characters.Include(c => c.City).Include(c => c.Categories).ThenInclude(c => c.Comics).Include(c => c.CharacterPowers).ThenInclude(cp => cp.Power).
                  Include(c => c.TeamCharacters).ThenInclude(tc => tc.Team).Include(c => c.ToyCharacters).ThenInclude(tc => tc.Toy).FirstOrDefault(c => c.Id == id),
               Cities = _db.Cities.ToList(),
               Powers = _db.Powers.ToList(),
               PowerList = new List<SelectListItem>(),
               CitiesList = new List<SelectListItem>(),
               
            };
            characterViewModel.Logo = characterViewModel.Character.Logo;
            characterViewModel.Profile = characterViewModel.Character.Profile;
            characterViewModel.LayoutImage = characterViewModel.Character.LayoutImage;
            characterViewModel.FirstImage = characterViewModel.Character.FirstImage;
            characterViewModel.SecondImage = characterViewModel.Character.SecondImage;
            if (characterViewModel.Character == null)
            {
                return BadRequest();
            }

            foreach (var power in characterViewModel.Powers)
            {
                characterViewModel.PowerList.AddRange(new List<SelectListItem>{
                    new SelectListItem() { Text = power.Name, Value = power.Id.ToString() }
                });
            }

            foreach (var city in characterViewModel.Cities)
            {
                characterViewModel.CitiesList.AddRange(new List<SelectListItem>{
                    new SelectListItem() { Text = city.Name, Value = city.Id.ToString() }
                });
            }
            return View(characterViewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(int? id, CharacterViewModel characterVM)
        {
            if (id == null || (id != characterVM.Character.Id))
            {
                return NotFound();
            }

           
            //if user don't choose image program enter here
            if (characterVM.Character.LogoPhoto == null)
            {
                characterVM.Character.Logo = characterVM.Logo;
                ModelState["Character.LogoPhoto"].ValidationState = ModelValidationState.Valid;
            }
            else
                characterVM.Character.Logo = RenderImage(characterVM.Character, characterVM.Character.LogoPhoto,characterVM.Logo);

            if (characterVM.Character.FirstPhoto == null)
            {
                characterVM.Character.FirstImage = characterVM.FirstImage;
                ModelState["Character.FirstPhoto"].ValidationState = ModelValidationState.Valid;
            }
            else
                characterVM.Character.FirstImage = RenderImage(characterVM.Character, characterVM.Character.FirstPhoto, characterVM.FirstImage);

            if (characterVM.Character.SecondPhoto == null)
            {
                characterVM.Character.SecondImage = characterVM.SecondImage;
                ModelState["Character.SecondPhoto"].ValidationState = ModelValidationState.Valid;
            }
            else
                characterVM.Character.SecondImage = RenderImage(characterVM.Character, characterVM.Character.SecondPhoto, characterVM.SecondImage);

            if (characterVM.Character.LayoutPhoto == null)
            {
                characterVM.Character.LayoutImage = characterVM.LayoutImage;
                ModelState["Character.LayoutPhoto"].ValidationState = ModelValidationState.Valid;
            }
            else
                characterVM.Character.LayoutImage = RenderImage(characterVM.Character, characterVM.Character.LayoutPhoto, characterVM.LayoutImage);

            if (characterVM.Character.ProfilePhoto == null)
            {
                characterVM.Character.Profile = characterVM.Profile;
                ModelState["Character.ProfilePhoto"].ValidationState = ModelValidationState.Valid;
            }
            else
                characterVM.Character.Profile = RenderImage(characterVM.Character, characterVM.Character.ProfilePhoto, characterVM.Profile);

            if (string.IsNullOrEmpty(characterVM.Character.Logo) || string.IsNullOrEmpty(characterVM.Character.FirstImage) ||
             string.IsNullOrEmpty(characterVM.Character.SecondImage) || string.IsNullOrEmpty(characterVM.Character.Profile) ||
             string.IsNullOrEmpty(characterVM.Character.LayoutImage))
            {
                ModelState.AddModelError("Image", "Image was incorrect");
                return View(characterVM);
            }

            if (!ModelState.IsValid)
                return View(characterVM.Character);


            _db.Characters.Update(characterVM.Character);
            _db.SaveChanges();

            int? characterId = characterVM.Character.Id;
            Character character = _db.Characters.Find(characterId);

            foreach (var power in characterVM.ChosenPowers)
            {
                Power pow = _db.Powers.FirstOrDefault(p => p.Id == power);
                CharacterPower characterPower = _db.CharacterPowers.FirstOrDefault(cp => cp.CharacterId == characterId && cp.PowerId == pow.Id);
                if (characterPower == null)
                {
                    characterPower = new CharacterPower();
                    characterPower.CharacterId = characterId;
                    characterPower.PowerId = pow.Id;
                    _db.CharacterPowers.Add(characterPower);
                }
                else
                {
                    characterPower.CharacterId = characterId;
                    characterPower.PowerId = pow.Id;
                    _db.CharacterPowers.Update(characterPower);
                }                 
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(Index), characterVM);

            }

        public ActionResult MakeActiveOrDeactive(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Character character = _db.Characters.Include(c => c.City).Include(c => c.Categories).ThenInclude(c => c.Comics).Include(c => c.CharacterPowers).ThenInclude(cp => cp.Power).
                  Include(c => c.TeamCharacters).ThenInclude(tc => tc.Team).Include(c => c.ToyCharacters).ThenInclude(tc => tc.Toy).FirstOrDefault(c => c.Id == id);

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


        public string RenderImage(Character character, IFormFile photo)
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
            newSlider = Path.Combine(newSlider, filename);

            using (FileStream file = new FileStream(newSlider, FileMode.Create))
            {
                photo.CopyTo(file);
            }

            return filename;

        }

            public string RenderImage(Character character, IFormFile photo,string oldFilename)
            {
            FileInfo oldFile = new FileInfo(oldFilename);
            if (System.IO.File.Exists(oldFilename))
            {
                oldFile.Delete();
            };

            return RenderImage(character, photo);
            }

       
        
    }
}

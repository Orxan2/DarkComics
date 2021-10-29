using DarkComics.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkComics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CharacterController : Controller
    {
        private readonly DarkComicDbContext _db;
        public CharacterController(DarkComicDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            return View();
        }
    }
}

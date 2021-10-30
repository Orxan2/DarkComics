using DarkComics.Models.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DarkComics.ViewModels
{
    public class CharacterViewModel
    {
        public List<Character> Characters { get; set; }
        public List<Power> Powers { get; set; }
        public List<SelectListItem> PowerList { get; set; }
        public List<int?> ChosenPowers { get; set; }
        public Character Character { get; set; }
    }
    }


using DarkComics.Models.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DarkComics.Models.Entity
{
    public class Character : BaseEntity
    {
        [Required, StringLength(maximumLength: 100)]
        public string Name { get; set; }
        public string HeroName { get; set; }
        public string FirstAppearance { get; set; }
        [BindNever]
        public string FirstImage { get; set; }
        [Required, NotMapped]
        public IFormFile FirstPhoto { get; set; }
        [BindNever]
        public string SecondImage { get; set; }
        [Required, NotMapped]
        public IFormFile SecondPhoto { get; set; }
        public string Profile { get; set; }
        [Required, NotMapped]
        public IFormFile ProfilePhoto { get; set; }
        public bool IsActive { get; set; }
        public string NickName { get; set; }
        public string AboutCharacter { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Category> Categories { get; set; }
        public List<ComicCharacter> ComicCharacters { get; set; }
        public List<TeamCharacter> TeamCharacters { get; set; }
        public List<ToyCharacter> ToyCharacters { get; set; }
        public List<CharacterPower> CharacterPowers { get; set; }

    }
}

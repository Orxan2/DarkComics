using DarkComics.Helpers.Enums;
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
    public class Comic : BaseEntity
    {
        [Required,StringLength(maximumLength:100)]
        public string Name { get; set; }
        [Required,NotMapped]
        public IFormFile Photo { get; set; }
        [BindNever]
        public string Image { get; set; }
        public int Volume { get; set; }
        public double Episode { get; set; }
        [Required]
        public double Price { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public bool IsTeam { get; set; }
        [Required]
        public int Quantity { get; set; }        
        public DateTime CreatedDate { get; set; }
        public Nullable<DateTime> DeActivatedDate { get; set; }
        [Required]
        public ComicType ComicType { get; set; }
        public Category Category { get; set; }
        public int? CategoryId { get; set; }        
        public Team Team { get; set; }
        public int? TeamId { get; set; }
        public List<ComicCharacter> ComicCharacters { get; set; }
    }
}

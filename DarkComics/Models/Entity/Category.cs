using DarkComics.Models.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DarkComics.Models.Entity
{
    public class Category : BaseEntity
    {
        [Required, StringLength(maximumLength: 100)]
        public string Name { get; set; }
        [Required, StringLength(maximumLength: 50)]
        public string Cover { get; set; }
        [Required, NotMapped]
        public IFormFile FirstPhoto { get; set; }
        public string Backface { get; set; }
        [Required, NotMapped]
        public IFormFile SecondPhoto { get; set; }
        public DateTime CreatedDate { get; set; }
        public Character Character { get; set; }
        public int? CharacterId { get; set; }
        public List<Comic> Comics { get; set; }
        //public int TeamId { get; set; }
    }
}

﻿using DarkComics.Helpers.Enums;
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
    public class Product : BaseEntity
    {
        [Required, StringLength(maximumLength: 100)]
        public string Name { get; set; }
        [Required, NotMapped]
        public IFormFile Photo { get; set; }
        [BindNever]
        public string Image { get; set; }
        //public int SaleQuantity { get; set; }
        //public int? CategoryId { get; set; }
        //public Category Category { get; set; }
        public Category Category { get; set; }
        [Required]
        public double Price { get; set; }
        //public double Discount { get; set; }
        public bool IsActive { get; set; }        
        [Required]
        public int? Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public DateTime DeActivatedDate { get; set; }
        public ComicDetail ComicDetail { get; set; }
        public int? ComicDetailId { get; set; }
        //public List<ComicDetail> ComicDetails { get; set; }
        public List<ProductCharacter> ProductCharacters { get; set; }
    }
}
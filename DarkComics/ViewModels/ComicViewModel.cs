﻿using DarkComics.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkComics.ViewModels
{
    public class ComicViewModel
    {
        public List<Product> RandomComics { get; set; }
        public List<Serie> Series { get; set; }
    }
}

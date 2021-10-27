using DarkComics.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkComics.ViewModels
{
    public class ComicViewModel
    {
        public List<Comic> Books { get; set; }
        public List<Comic> OneShot { get; set; }
        public List<Comic> Series { get; set; }
        public List<Category> Categories { get; set; }
        public int ComicQuantity { get; set; }
        
    }
}

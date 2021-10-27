using DarkComics.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkComics.ViewModels
{
    public class HomeViewModel
    {
        public List<Comic> Comics;
        public List<Comic> FilteringComics;
        public List<Comic> BestComics;
        public List<Character> Characters;
       
    }
}

using DarkComics.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkComics.Models.Entity
{
    public class ComicCharacter : BaseEntity
    {
        public Comic Comic { get; set; }
        public int? ComicId { get; set; }
        public Character Character { get; set; }
        public int? CharacterId { get; set; }
        
    }
}

using DarkComics.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkComics.Models.Entity
{
    public class TeamCharacter : BaseEntity
    {
        public Team Team { get; set; }
        public int? TeamId { get; set; }
        public Character Character { get; set; }
        public int? CharacterId { get; set; }
    }
}

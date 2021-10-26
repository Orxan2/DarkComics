using DarkComics.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DarkComics.Models.Entity
{
    public class Team : BaseEntity
    {
        [Required, StringLength(maximumLength: 100)]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Comic> Comics { get; set; }
        public List<TeamCharacter> TeamCharacters { get; set; }

    }
}

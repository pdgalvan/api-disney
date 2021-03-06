using System;
using System.Collections.Generic;
using System.Text;

namespace Disney.Domain.Entities
{
    public class Character
    {
        public Guid CharacterId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public List<MovieCharacter> MovieCharacters { get; set; }

        
    }
}

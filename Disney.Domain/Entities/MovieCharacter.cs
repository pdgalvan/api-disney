using System;
using System.Collections.Generic;
using System.Text;

namespace Disney.Domain.Entities
{
    public class MovieCharacter
    {
        public  Guid MovieId { get; set; }
        public Movie Movie { get; set; }

        public Guid CharacterId { get; set; }
        public Character Character { get; set; }
    }
}

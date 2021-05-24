using System;
using System.Collections.Generic;
using System.Text;

namespace Disney.Domain.Entities
{
    public class Genre
    {
        public Guid GenreId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public IEnumerable<MovieGenre> MovieGenres { get; set; }
        
    }
}

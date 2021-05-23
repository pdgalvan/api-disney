﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Disney.Domain.Entities
{
    public class Movie
    {
        public Guid MovieId { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Rating Rating { get; set; }
        public string ImageUrl { get; set; }

        public IEnumerable<MovieCharacter> MovieCharacters { get; set; }
        public IEnumerable<MovieGenre> MovieGenres { get; set; }

        

    }
}

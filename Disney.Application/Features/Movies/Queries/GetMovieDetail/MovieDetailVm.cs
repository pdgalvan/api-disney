using System;
using System.Collections.Generic;

namespace Disney.Application.Features.Movies.Queries.GetMovieDetail
{
    public class MovieDetailVm
    {
        public Guid MovieId { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Rating { get; set; }
        public string ImageUrl { get; set; }

        public List<GenreDto> Genres { get; set; }
        public List<CharacterDto> Characters { get; set; }
    }
}

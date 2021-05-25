using System;
using System.Collections.Generic;
using System.Text;

namespace Disney.Application.Features.Movies.Queries.GetMovieList
{
    public class MovieListVm
    {
        public Guid MovieId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}

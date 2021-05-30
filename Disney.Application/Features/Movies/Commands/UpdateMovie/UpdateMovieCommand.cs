using MediatR;
using System;
using System.Collections.Generic;

namespace Disney.Application.Features.Movies.Commands.UpdateMovie
{
    public class UpdateMovieCommand : IRequest
    {
        public Guid MovieId { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Rating { get; set; }
        public string ImageUrl { get; set; }

        public List<Guid> Characters { get; set; }
        public List<Guid> Genres { get; set; }
    }
}

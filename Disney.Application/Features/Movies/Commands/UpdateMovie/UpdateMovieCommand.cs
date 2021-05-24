using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disney.Application.Features.Movies.Commands.UpdateMovie
{
    public class UpdateMovieCommand : IRequest
    {
        public Guid MovieId { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        //public Rating Rating { get; set; }
        public string ImageUrl { get; set; }

    }
}

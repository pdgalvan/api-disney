using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disney.Application.Features.Movies.Commands.CreateMovie
{
    public class CreateMovieCommand : IRequest<Guid>
    {
        
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        //public Rating Rating { get; set; }
        public string ImageUrl { get; set; }
    }
}

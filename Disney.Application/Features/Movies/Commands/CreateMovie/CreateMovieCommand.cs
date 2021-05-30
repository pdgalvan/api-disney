using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disney.Application.Features.Movies.Commands.CreateMovie
{
    public class CreateMovieCommand : IRequest<CreateMovieCommandResponse>
    {
        
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Rating { get; set; }
        public string ImageUrl { get; set; }

        public List<Guid> Characters { get; set; }
        public List<Guid> Genres { get; set; }
    }
}

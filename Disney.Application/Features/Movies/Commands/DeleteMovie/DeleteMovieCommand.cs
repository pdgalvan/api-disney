using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disney.Application.Features.Movies.Commands.DeleteMovie
{
    public class DeleteMovieCommand : IRequest 
    {
        public Guid MovieId { get; set; }
    }
}

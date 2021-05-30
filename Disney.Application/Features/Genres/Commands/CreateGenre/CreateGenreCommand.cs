using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disney.Application.Features.Genres.Commands.CreateGenre
{
    public class CreateGenreCommand : IRequest<CreateGenreCommandResponse>
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public List<Guid> Movies { get; set; }
    }
}

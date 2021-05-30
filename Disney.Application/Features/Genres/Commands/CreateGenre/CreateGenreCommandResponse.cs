using Disney.Application.Responses;
using System;

namespace Disney.Application.Features.Genres.Commands.CreateGenre
{
    public class CreateGenreCommandResponse : BaseResponse
    {
        public CreateGenreCommandResponse()
            : base()
        {

        }

        public Guid GenreId { get; set; }


    }
}

using Disney.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disney.Application.Features.Movies.Commands.CreateMovie
{
    public class CreateMovieCommandResponse : BaseResponse
    {
        public CreateMovieCommandResponse()
            :base()
        {

        }

        public Guid MovieId { get; set; }
    }
}

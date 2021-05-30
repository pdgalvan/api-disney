using Disney.Application.Features.Genres.Commands.CreateGenre;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disney.Api.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenreController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        public async Task<ActionResult<CreateGenreCommandResponse>> Create ([FromBody] CreateGenreCommand createGenreCommand)
        {
            var response = await _mediator.Send(createGenreCommand);
            return Ok(response);
        }
        
    }
}

using Disney.Application.Features.Movies.Commands.CreateMovie;
using Disney.Application.Features.Movies.Queries.GetMovieList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disney.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllMovies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<MovieListVm>>> GetAllMovies()
        {
            var dtos = await _mediator.Send(new GetMovieListQuery());
            return Ok(dtos);
        }

        [HttpPost(Name = "AddMovie")]
        public async Task<ActionResult<CreateMovieCommandResponse>> Create([FromBody] CreateMovieCommand createMovieCommand)
        {
            var response = await _mediator.Send(createMovieCommand);
            return Ok(response);
        }
    }
}

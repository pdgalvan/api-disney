using Disney.Application.Features.Movies.Commands.CreateMovie;
using Disney.Application.Features.Movies.Commands.DeleteMovie;
using Disney.Application.Features.Movies.Commands.UpdateMovie;
using Disney.Application.Features.Movies.Queries.GetMovieDetail;
using Disney.Application.Features.Movies.Queries.GetMovieList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disney.Api.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<MovieListVm>>> GetMovies([FromQuery] GetMovieListQuery getMovieListQuery)
        {

            var movieListVm = await _mediator.Send(getMovieListQuery);

            return Ok(movieListVm);
        }

        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MovieDetailVm>> GetMovie(Guid id)
        {
            var movieDetailVm = await _mediator.Send(new GetMovieDetailQuery() { Id = id });

            if (movieDetailVm == null)
                return NotFound();

            return Ok(movieDetailVm);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<CreateMovieCommandResponse>> Create([FromBody] CreateMovieCommand createMovieCommand)
        {
            var response = await _mediator.Send(createMovieCommand);
            return Ok(response);
        }

        [Authorize]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update ([FromBody] UpdateMovieCommand updateMovieCommand)
        {
            await _mediator.Send(updateMovieCommand);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete (Guid id)
        {
            var deleteMovieCommand = new DeleteMovieCommand() { MovieId = id };
            await _mediator.Send(deleteMovieCommand);
            return NoContent();
        }
    }
}

using Disney.Application.Features.Characters.Commands.CreateCharacter;
using Disney.Application.Features.Characters.Queries.GetCharacterList;
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
    public class CharacterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CharacterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllCharacters")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CharacterListVm>>> GetAllCharacters()
        {
            var dtos = await _mediator.Send(new GetCharacterListQuery());
            return Ok(dtos);
        }

        [HttpPost(Name = "AddCharacter")]
        public async Task<ActionResult<CreateCharacterCommandResponse>> Create([FromBody] CreateCharacterCommand createCharacterCommand)
        {
            var response = await _mediator.Send(createCharacterCommand);
            return Ok(response);
        }

    }
}

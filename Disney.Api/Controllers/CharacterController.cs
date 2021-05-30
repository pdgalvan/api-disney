 using Disney.Application.Features.Characters.Commands.CreateCharacter;
using Disney.Application.Features.Characters.Commands.DeleteCharacter;
using Disney.Application.Features.Characters.Commands.UpdateCharacter;
using Disney.Application.Features.Characters.Queries.GetCharacterDetail;
using Disney.Application.Features.Characters.Queries.GetCharacterList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disney.Api.Controllers
{
    [Route("api/characters")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CharacterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CharacterListVm>>> GetCharacters([FromQuery] GetCharacterListQuery getCharacterListQuery)
        {
            var dtos = await _mediator.Send(getCharacterListQuery);
            return Ok(dtos);
        }

        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CharacterDetailVm>> GetCharacter(Guid id)
        {
            var characterDeailVm = await _mediator.Send(new GetCharacterDetailQuery() { Id = id });

            if (characterDeailVm == null)
                return NotFound();

            return Ok(characterDeailVm);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<CreateCharacterCommandResponse>> Create([FromBody] CreateCharacterCommand createCharacterCommand)
        {
            var response = await _mediator.Send(createCharacterCommand);
            return Ok(response);
        }

        [Authorize]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateCharacterCommand updateCharacterCommand)
        {
            await _mediator.Send(updateCharacterCommand);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteCharacterCommand = new DeleteCharacterCommand() { CharacterId = id };
            await _mediator.Send(deleteCharacterCommand);
            return NoContent();
        }
    }
}

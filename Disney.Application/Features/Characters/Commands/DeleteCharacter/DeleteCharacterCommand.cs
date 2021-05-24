using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disney.Application.Features.Characters.Commands.DeleteCharacter
{
    class DeleteCharacterCommand : IRequest
    {
        public Guid CharacterId { get; set; }
    }
}

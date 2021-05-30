using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disney.Application.Features.Characters.Commands.DeleteCharacter
{
    public class DeleteCharacterCommand : IRequest
    {
        public Guid CharacterId { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disney.Application.Features.Characters.Commands.UpdateCharacter
{
    class UpdateCharacterCommand : IRequest
    {
        public Guid CharacterId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}

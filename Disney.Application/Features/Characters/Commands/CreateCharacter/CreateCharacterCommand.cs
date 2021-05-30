using MediatR;
using System;
using System.Collections.Generic;

namespace Disney.Application.Features.Characters.Commands.CreateCharacter
{
    public class CreateCharacterCommand : IRequest<CreateCharacterCommandResponse>
    {
        
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public List<Guid> Movies { get; set; }
    } 
}

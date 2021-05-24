﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disney.Application.Features.Characters.Commands.CreateCharacter
{
    public class CreateCharacterCommand : IRequest<Guid>
    {
        
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return $"Character name:{Name}; Age:{Age}; Weight: {Weight}";
        }
    } 
}

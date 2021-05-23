using System;
using System.Collections.Generic;
using System.Text;

namespace Disney.Application.Features.Characters.Queries.GetCharacterList
{
    public class CharacterListVm
    {
        public Guid CharacterId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        
    }
}

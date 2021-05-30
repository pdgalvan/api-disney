using System;
using System.Collections.Generic;

namespace Disney.Application.Features.Characters.Queries.GetCharacterDetail
{
    public class CharacterDetailVm
    {
        public Guid CharacterId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public List<MovieDto> Movies { get; set; }
    }
}

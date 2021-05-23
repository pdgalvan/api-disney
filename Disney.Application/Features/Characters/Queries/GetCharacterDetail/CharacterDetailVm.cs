using System;
using System.Collections.Generic;
using System.Text;

namespace Disney.Application.Features.Characters.Queries.GetCharacterDetail
{
    class CharacterDetailVm
    {
        public Guid CharacterId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string Story { get; set; }
        public string ImageUrl { get; set; }

    }
}

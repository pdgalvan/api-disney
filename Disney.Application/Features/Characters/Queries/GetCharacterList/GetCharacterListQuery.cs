using MediatR;
using System;
using System.Collections.Generic;

namespace Disney.Application.Features.Characters.Queries.GetCharacterList
{
    public class GetCharacterListQuery : IRequest<List<CharacterListVm>>
    {
        public string Name { get; set; }
        public int? Weight { get; set; }
        public int? Age { get; set; }

        public Guid? MovieId { get; set; }
    }
}

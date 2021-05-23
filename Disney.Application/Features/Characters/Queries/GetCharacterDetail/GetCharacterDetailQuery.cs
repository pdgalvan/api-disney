using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disney.Application.Features.Characters.Queries.GetCharacterDetail
{
    class GetCharacterDetailQuery : IRequest<CharacterDetailVm>
    {
        public Guid Id { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disney.Application.Features.Characters.Queries.GetCharacterDetail
{
    public class GetCharacterDetailQuery : IRequest<CharacterDetailVm>
    {
        public Guid Id { get; set; }
    }
}

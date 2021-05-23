using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disney.Application.Features.Characters.Queries.GetCharacterList
{
    public class GetCharacterListQuery : IRequest<List<CharacterListVm>>
    {

    }
}

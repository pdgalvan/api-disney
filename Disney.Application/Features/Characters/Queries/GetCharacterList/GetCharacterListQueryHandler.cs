using AutoMapper;
using Disney.Application.Contracts.Persistence;
using Disney.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Disney.Application.Features.Characters.Queries.GetCharacterList
{
    public class GetCharacterListQueryHandler : IRequestHandler<GetCharacterListQuery, List<CharacterListVm>>
    {
        private readonly IMapper _mapper;
        private readonly ICharacterRepository _characterRepository;

        public GetCharacterListQueryHandler(IMapper mapper,
                                            ICharacterRepository characterRepository )
        {
            _mapper = mapper;
            _characterRepository = characterRepository;
        }
        public async Task<List<CharacterListVm>> Handle(GetCharacterListQuery request, 
                                                  CancellationToken cancellationToken)
        {
            var allCharacters = await _characterRepository.GetCharacters(request);
            return _mapper.Map<List<CharacterListVm>>(allCharacters);
        }
    }
}

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
        private readonly IAsyncRepository<Character> _characterRepository;

        public GetCharacterListQueryHandler(IMapper mapper,
                                            IAsyncRepository<Character> characterRepository )
        {
            _mapper = mapper;
            _characterRepository = characterRepository;
        }
        public async Task<List<CharacterListVm>> Handle(GetCharacterListQuery request, 
                                                  CancellationToken cancellationToken)
        {
            var allCharacters = (await _characterRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<CharacterListVm>>(allCharacters);
        }
    }
}

using AutoMapper;
using Disney.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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

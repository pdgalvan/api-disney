using AutoMapper;
using Disney.Application.Contracts.Persistence;
using Disney.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disney.Application.Features.Characters.Queries.GetCharacterDetail
{
    class GetCharacterDetailQueryHandler : IRequestHandler<GetCharacterDetailQuery, CharacterDetailVm>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Character> _characterRepository;

        public GetCharacterDetailQueryHandler(IMapper mapper,
                                              IAsyncRepository<Character> characterRepository)
                                              
        {
            _mapper = mapper;
            _characterRepository = characterRepository;
        }

        public async Task<CharacterDetailVm> Handle(GetCharacterDetailQuery request,
                                              CancellationToken cancellationToken)
        {
            var @character = await _characterRepository.GetByIdAsync(request.Id);
            var characterDetailDto = _mapper.Map<CharacterDetailVm>(@character);

            return characterDetailDto;
        }
    }
}

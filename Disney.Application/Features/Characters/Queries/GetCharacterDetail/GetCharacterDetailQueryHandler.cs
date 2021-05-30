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
        private readonly ICharacterRepository _characterRepository;

        public GetCharacterDetailQueryHandler(IMapper mapper,
                                              ICharacterRepository characterRepository)
        {
            _mapper = mapper;
            _characterRepository = characterRepository;
        }

        public async Task<CharacterDetailVm> Handle(GetCharacterDetailQuery request,
                                              CancellationToken cancellationToken)
        {
            var character = await _characterRepository.GetCharacterDetails(request.Id);
            var characterDetailVm = _mapper.Map<CharacterDetailVm>(character);

            characterDetailVm.Movies = new List<MovieDto>();
            foreach (var movieCharacter in character.MovieCharacters)
                characterDetailVm.Movies.Add(_mapper.Map<MovieDto>(movieCharacter.Movie));

            return characterDetailVm;
        }
    }
}

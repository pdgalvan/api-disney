using AutoMapper;
using Disney.Application.Contracts.Persistence;
using Disney.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disney.Application.Features.Characters.Commands.UpdateCharacter
{
    public class UpdateCharacterCommandHandler : IRequestHandler<UpdateCharacterCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Character> _characterRepository;
        private readonly IAsyncRepository<Movie> _movieRepository;

        public UpdateCharacterCommandHandler(IMapper mapper,
                                             IAsyncRepository<Character> characterRepository, IAsyncRepository<Movie> movieRepository)
        {
            _mapper = mapper;
            _characterRepository = characterRepository;
            _movieRepository = movieRepository;
        }
        public  async Task<Unit> Handle(UpdateCharacterCommand request, CancellationToken cancellationToken)
        {
            var characterToUpdate = await _characterRepository.GetByIdAsync(request.CharacterId);
            _mapper.Map(request, characterToUpdate, typeof(UpdateCharacterCommand), typeof(Character));
            await _characterRepository.UpdateAsync(characterToUpdate);

            return Unit.Value;
        }
    }
}

using AutoMapper;
using Disney.Application.Contracts.Persistence;
using Disney.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disney.Application.Features.Characters.Commands.CreateCharacter
{
    public class CreateCharacterCommandHandler : IRequestHandler<CreateCharacterCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly ICharacterRepository _characterRepository;

        public CreateCharacterCommandHandler(IMapper mapper, 
                                             ICharacterRepository characterRepository)
        {
            _mapper = mapper;
            _characterRepository = characterRepository;
        }
        public async Task<Guid> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
        {
            var @character = _mapper.Map<Character>(request);
            @character = await _characterRepository.AddAsync(@character);

            return character.CharacterId;
        }
    }
}

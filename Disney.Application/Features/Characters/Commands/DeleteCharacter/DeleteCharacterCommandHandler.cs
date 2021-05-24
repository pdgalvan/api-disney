using AutoMapper;
using Disney.Application.Contracts.Persistence;
using Disney.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disney.Application.Features.Characters.Commands.DeleteCharacter
{
    class DeleteCharacterCommandHandler : IRequestHandler<DeleteCharacterCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Character> _characterRepository;

        public DeleteCharacterCommandHandler(IMapper mapper,
                                             IAsyncRepository<Character> characterRepository)
        {
            _mapper = mapper;
            _characterRepository = characterRepository;
        }
        public async Task<Unit> Handle(DeleteCharacterCommand request, CancellationToken cancellationToken)
        {
            var characterToDelete = await _characterRepository.GetByIdAsync(request.CharacterId);
            await _characterRepository.DeleteAsync(characterToDelete);

            return Unit.Value;
        }
    }
}

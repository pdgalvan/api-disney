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
    public class CreateCharacterCommandHandler : IRequestHandler<CreateCharacterCommand, CreateCharacterCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Character> _characterRepository;

        public CreateCharacterCommandHandler(IMapper mapper, 
                                             IAsyncRepository<Character> characterRepository)
        {
            _mapper = mapper;
            _characterRepository = characterRepository;
        }
        public async Task<CreateCharacterCommandResponse> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
        {
            var createCharacterCommandResponse = new CreateCharacterCommandResponse();

            var validator = new CreateCharacterCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createCharacterCommandResponse.Success = false;
                createCharacterCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createCharacterCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createCharacterCommandResponse.Success)
            {
                var character = await _characterRepository.AddAsync(new Character() { Name = request.Name, Age=request.Age, Weight= request.Weight , Description = request.Description, ImageUrl = request.ImageUrl });
                createCharacterCommandResponse.CharacterId = character.CharacterId;
              }
            return createCharacterCommandResponse;
        }
    }
}

using AutoMapper;
using Disney.Application.Contracts.Persistence;
using Disney.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disney.Application.Features.Genres.Commands.CreateGenre
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, CreateGenreCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenreRepository _genreRepository;


        public CreateGenreCommandHandler(IMapper mapper,
                                         IGenreRepository genreRepostiroy)
        {
            _mapper = mapper;
            _genreRepository = genreRepostiroy;
        }
        
        public async Task<CreateGenreCommandResponse> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var createGenreCommandResponse = new CreateGenreCommandResponse();

            var validator = new CreateGenreCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if(validationResult.Errors.Count > 0)
            {
                createGenreCommandResponse.Success = false;
                createGenreCommandResponse.ValidationErrors = new List<string>();
                foreach(var error in validationResult.Errors)
                {
                    createGenreCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createGenreCommandResponse.Success)
            {
                createGenreCommandResponse.GenreId = await _genreRepository.CreateGenre(request);
            }
            return createGenreCommandResponse;
        }
    }
}

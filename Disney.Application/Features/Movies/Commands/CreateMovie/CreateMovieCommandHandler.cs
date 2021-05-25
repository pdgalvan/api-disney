using AutoMapper;
using Disney.Application.Contracts.Persistence;
using Disney.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Disney.Application.Features.Movies.Commands.CreateMovie
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, CreateMovieCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Movie> _movieRepository;

        public CreateMovieCommandHandler(IMapper mapper,
                                        IAsyncRepository<Movie> movieRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        public async Task<CreateMovieCommandResponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var createMovieCommandResponse = new CreateMovieCommandResponse();

            var validator = new CreateMovieCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if(validationResult.Errors.Count > 0)
            {
                createMovieCommandResponse.Success = false;
                createMovieCommandResponse.ValidationErrors = new List<string>();
                foreach(var error in validationResult.Errors)
                {
                    createMovieCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if(createMovieCommandResponse.Success)
            {
                var movie = new Movie() { Name = request.Name };
                movie = await _movieRepository.AddAsync(movie);
                createMovieCommandResponse.Movie = _mapper.Map<CreateMovieDto>(movie);
            }
            return createMovieCommandResponse;
        }

       
    }
}

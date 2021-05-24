using AutoMapper;
using Disney.Application.Contracts.Persistence;
using Disney.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disney.Application.Features.Movies.Commands.CreateMovie
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;

        public CreateMovieCommandHandler(IMapper mapper,
                                        IMovieRepository movieRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        public async Task<Guid> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var @movie = _mapper.Map<Movie>(request);
            @movie = await _movieRepository.AddAsync(@movie);

            return movie.MovieId;
        }
    }
}

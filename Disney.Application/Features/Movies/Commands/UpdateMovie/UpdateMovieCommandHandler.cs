using AutoMapper;
using Disney.Application.Contracts.Persistence;
using Disney.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disney.Application.Features.Movies.Commands.UpdateMovie
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Movie> _movieRepository;

        public UpdateMovieCommandHandler(IMapper mapper,
                                         IAsyncRepository<Movie> movieRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }
        public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movieToUpdate = await _movieRepository.GetByIdAsync(request.MovieId);
            _mapper.Map(request, movieToUpdate, typeof(UpdateMovieCommand), typeof(Movie));
            await _movieRepository.UpdateAsync(movieToUpdate);

            return Unit.Value;
        }
    }
}

using AutoMapper;
using Disney.Application.Contracts.Persistence;
using Disney.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disney.Application.Features.Movies.Commands.DeleteMovie
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Movie> _movieRepository;

        public DeleteMovieCommandHandler(IMapper mapper,
                                        IAsyncRepository<Movie> movieRepository )
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }
        public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movieToDelete = await _movieRepository.GetByIdAsync(request.MovieId);
            await _movieRepository.DeleteAsync(movieToDelete);

            return Unit.Value;
        }
    }
}

using AutoMapper;
using Disney.Application.Contracts.Persistence;
using Disney.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disney.Application.Features.Movies.Queries.GetMovieDetail
{
    class GetMovieDetailQueryHandler : IRequestHandler<GetMovieDetailQuery, MovieDetailVm>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Movie> _movieRepository;

        public GetMovieDetailQueryHandler(IMapper mapper,
                                          IAsyncRepository<Movie> movieRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        public async Task<MovieDetailVm> Handle(GetMovieDetailQuery request, CancellationToken cancellationToken)
        {
            var @movie = await _movieRepository.GetByIdAsync(request.Id);
            var movieDetailDto = _mapper.Map<MovieDetailVm>(@movie);

            return movieDetailDto;
        }
    }
}

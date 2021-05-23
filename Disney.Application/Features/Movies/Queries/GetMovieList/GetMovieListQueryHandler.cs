using AutoMapper;
using Disney.Application.Contracts.Persistence;
using Disney.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
namespace Disney.Application.Features.Movies.Queries.GetMovieList
{
    class GetMovieListQueryHandler : IRequestHandler<GetMovieListQuery, List<MovieListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Movie> _movieRepository;

        public GetMovieListQueryHandler(IMapper mapper,
                                        IAsyncRepository<Movie> movieRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;

        }
        public async Task<List<MovieListVm>> Handle(GetMovieListQuery request, CancellationToken cancellationToken)
        {
            var allMovies = (await _movieRepository.ListAllAsync()).OrderBy(x => x.ReleaseDate);
            return _mapper.Map<List<MovieListVm>>(allMovies);
        }
    }
}

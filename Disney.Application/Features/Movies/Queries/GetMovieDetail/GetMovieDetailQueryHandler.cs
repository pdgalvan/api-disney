using AutoMapper;
using Disney.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Disney.Application.Features.Movies.Queries.GetMovieDetail
{
    public class GetMovieDetailQueryHandler : IRequestHandler<GetMovieDetailQuery, MovieDetailVm>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;

        public GetMovieDetailQueryHandler(IMapper mapper,
                                          IMovieRepository movieRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        public async Task<MovieDetailVm> Handle(GetMovieDetailQuery request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetMovieDetails(request.Id);

            if (movie == null) return null;

            var movieDetailVm = _mapper.Map<MovieDetailVm>(movie);

            movieDetailVm.Characters = new List<CharacterDto>();
            movieDetailVm.Genres = new List<GenreDto>();

            foreach (var movieGenre in movie.MovieGenres)
                movieDetailVm.Genres.Add(_mapper.Map<GenreDto>(movieGenre.Genre));

            foreach (var movieCharacter in movie.MovieCharacters)
                movieDetailVm.Characters.Add(_mapper.Map<CharacterDto>(movieCharacter.Character));
                
            return movieDetailVm;
        }
    }
}

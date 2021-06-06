using AutoMapper;
using Disney.Application.Contracts.Persistence;
using Disney.Domain.Entities;
using Disney.Domain.Enumerations;
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
        private readonly IAsyncRepository<Character> _characterRepository;
        private readonly IAsyncRepository<Genre> _genreRepository;

        public CreateMovieCommandHandler(IMapper mapper,
                                        IAsyncRepository<Movie> movieRepository, IAsyncRepository<Genre> genreRepository, IAsyncRepository<Character> characterRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _characterRepository = characterRepository;
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
                var movie = await _movieRepository.AddAsync(new Movie() { Name = request.Name, ReleaseDate = request.ReleaseDate, ImageUrl = request.ImageUrl, Rating = (Rating)request.Rating });

                var characters = await _characterRepository.ListAllAsync();
                movie.MovieCharacters = new List<MovieCharacter>();
                foreach (var character in characters)
                {
                    if(request.Characters.Contains(character.CharacterId))
                        movie.MovieCharacters.Add(new MovieCharacter()
                        {
                            CharacterId = character.CharacterId, MovieId = movie.MovieId
                        });
                }

                var genres = await _genreRepository.ListAllAsync();
                movie.MovieGenres = new List<MovieGenre>();
                foreach (var genre in genres)
                {
                    if(request.Genres.Contains(genre.GenreId))
                        movie.MovieGenres.Add(new MovieGenre()
                        {
                            GenreId = genre.GenreId, MovieId = movie.MovieId
                        });
                }

                await _movieRepository.UpdateAsync(movie);
                
                createMovieCommandResponse.MovieId = movie.MovieId;
            }
            return createMovieCommandResponse;
        }

       
    }
}

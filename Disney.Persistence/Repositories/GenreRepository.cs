using Disney.Application.Contracts.Persistence;
using Disney.Application.Features.Genres.Commands.CreateGenre;
using Disney.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disney.Persistence.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(DisneyDbContext dbContext)
            :base(dbContext)
        {

        }

        public async Task<Guid> CreateGenre(CreateGenreCommand request)
        {

            var genre = await AddAsync(new Genre() { ImageUrl = request.ImageUrl, Name = request.Name });

            if(request.Movies.Count > 0)
            {
                foreach(var movieId in request.Movies)
                {
                    await _dbContext.MovieGenres.AddAsync(new MovieGenre() { GenreId = genre.GenreId, MovieId = movieId });
                }
            }
            return genre.GenreId;
            }


        public Task<bool> IsGenreNameUnique(string name)
        {
            var match = _dbContext.Genres.Any(g => g.Name.Equals(name));
            return Task.FromResult(match);
        }
    }
}

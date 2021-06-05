using Disney.Application.Contracts.Persistence;
using Disney.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Disney.Application.Features.Movies.Queries.GetMovieList;

namespace Disney.Persistence.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(DisneyDbContext dbContext)
            : base(dbContext)
        {

        }
        
        public  async Task<Movie> GetMovieDetails(Guid id)
        {
            
            return await _dbContext.Movies
                                    .Include(x => x.MovieCharacters)
                                        .ThenInclude(x => x.Character)
                                    .Include(x => x.MovieGenres)
                                        .ThenInclude(x => x.Genre)
                                    .Where(x => x.MovieId == id)
                                    .FirstOrDefaultAsync();
        }

        public async Task<List<Movie>> GetMovies(GetMovieListQuery getMovieListQuery)
        {
            var movieList = await _dbContext.Movies.Include(x => x.MovieGenres).ToListAsync();

             
            if (getMovieListQuery.GenreId != null)
            {
                movieList = movieList.Where(m => m.MovieGenres.Any(mg => mg.GenreId == getMovieListQuery.GenreId)).ToList();
                
            }

            if(getMovieListQuery.Title != null)
            {
                movieList = movieList.Where(m => m.Name.ToLower().Contains(getMovieListQuery.Title.ToLower())).ToList();
            }

            if(getMovieListQuery.OrderbyDate != null)
            {
                movieList = getMovieListQuery.OrderbyDate switch
                {
                    "asc" => movieList.OrderBy(x => x.ReleaseDate).ToList(),
                    "desc" => movieList.OrderByDescending(x => x.ReleaseDate).ToList(),
                    _ => movieList
                };
            }

            return movieList;
        }

        public Task<bool> IsMovieNameUnique(string name)
        {
            var match = _dbContext.Movies.Any(m => m.Name.Equals(name));
            return Task.FromResult(match);
        }

    }
}

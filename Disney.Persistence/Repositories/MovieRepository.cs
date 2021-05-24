using Disney.Application.Contracts.Persistence;
using Disney.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disney.Persistence.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(DisneyDbContext dbContext)
            : base(dbContext)
        {

        }

        public Task<bool> IsMovieNameUnique(string name)
        {
            var match = _dbContext.Movies.Any(m => m.Name.Equals(name));
            return Task.FromResult(match);
        }

    }
}

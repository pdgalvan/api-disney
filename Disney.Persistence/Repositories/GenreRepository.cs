using Disney.Application.Contracts.Persistence;
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

        public Task<bool> IsGenreNameUnique(string name)
        {
            var match = _dbContext.Genres.Any(g => g.Name.Equals(name));
            return Task.FromResult(match);
        }
    }
}

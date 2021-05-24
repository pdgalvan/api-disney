using Disney.Application.Contracts.Persistence;
using Disney.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disney.Persistence.Repositories
{
    public class CharacterRepository : BaseRepository<Character>, ICharacterRepository
    {
        public CharacterRepository(DisneyDbContext dbContext)
            :base(dbContext)
        {

        }
        public Task<bool> IsCharacterNameUnique(string name)
        {
            var match = _dbContext.Characters.Any(c => c.Name.Equals(name));
            return Task.FromResult(match);
            
        }
    }
}

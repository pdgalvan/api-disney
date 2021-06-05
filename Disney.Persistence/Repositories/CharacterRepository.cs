using Disney.Application.Contracts.Persistence;
using Disney.Application.Features.Characters.Queries.GetCharacterList;
using Disney.Domain.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Character> GetCharacterDetails(Guid id)
        {
            return await _dbContext.Characters
                                   .Include(x => x.MovieCharacters)
                                    .ThenInclude(x =>x.Movie)
                                   .Where(x => x.CharacterId == id)
                                   .FirstOrDefaultAsync();
        }

        public async Task<List<Character>> GetCharacters(GetCharacterListQuery request)
        {
            var characterList = await _dbContext.Characters.Include(x=> x.MovieCharacters).ToListAsync();

            if(request.MovieId != null)
            {
                characterList = characterList.Where(c => c.MovieCharacters.Any(mc => mc.MovieId == request.MovieId))
                    .ToList();
            }
            if(request.Age != null)
            {
                characterList = characterList.Where(c => c.Age == request.Age).ToList();
            }
            if (request.Weight != null)
            {
                characterList = characterList.Where(c => c.Weight == request.Weight).ToList();
            }
            if (request.Name != null)
            {
                characterList = characterList.Where(c => c.Name.ToLower().Contains(request.Name.ToLower())).ToList();
            }
            return characterList;
        }

        public Task<bool> IsCharacterNameUnique(string name)
        {
            var match = _dbContext.Characters.Any(c => c.Name.Equals(name));
            return Task.FromResult(match);
            
        }
        
    }
}

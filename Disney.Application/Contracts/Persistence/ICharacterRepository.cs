using Disney.Application.Features.Characters.Queries.GetCharacterList;
using Disney.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disney.Application.Contracts.Persistence
{
    public interface ICharacterRepository : IAsyncRepository<Character>
    {
        public Task<bool> IsCharacterNameUnique(string name);
        public Task<Character> GetCharacterDetails(Guid id);
        public Task<List<Character>> GetCharacters(GetCharacterListQuery request);
    }
}

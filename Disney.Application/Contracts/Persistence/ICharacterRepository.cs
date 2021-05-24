using Disney.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disney.Application.Contracts.Persistence
{
    public interface ICharacterRepository : IAsyncRepository<Character>
    {
        public Task<bool> IsCharacterNameUnique(string name);
    }
}

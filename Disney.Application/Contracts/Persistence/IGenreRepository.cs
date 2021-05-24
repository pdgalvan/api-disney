using Disney.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disney.Application.Contracts.Persistence
{
    public interface IGenreRepository : IAsyncRepository<Genre>
    {
        public Task<bool> IsGenreNameUnique(string name);
    }
}

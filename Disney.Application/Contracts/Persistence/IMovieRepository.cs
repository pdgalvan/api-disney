using Disney.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disney.Application.Contracts.Persistence
{
    public interface IMovieRepository : IAsyncRepository<Movie>
    {
        public Task<bool> IsMovieNameUnique(string name);
    }
}

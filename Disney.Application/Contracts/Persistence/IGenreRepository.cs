using Disney.Application.Features.Genres.Commands.CreateGenre;
using Disney.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Disney.Application.Contracts.Persistence
{
    public interface IGenreRepository : IAsyncRepository<Genre>
    {
        public Task<bool> IsGenreNameUnique(string name);
        public Task<Guid> CreateGenre(CreateGenreCommand request);
    }
}

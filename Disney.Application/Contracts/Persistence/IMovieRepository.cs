using Disney.Application.Features.Movies.Queries.GetMovieList;
using Disney.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disney.Application.Contracts.Persistence
{
    public interface IMovieRepository : IAsyncRepository<Movie>
    {
        public Task<bool> IsMovieNameUnique(string name);
        public Task<Movie> GetMovieDetails(Guid id);
        public Task<List<Movie>> GetMovies(GetMovieListQuery getMovieListQuery);
    }
}

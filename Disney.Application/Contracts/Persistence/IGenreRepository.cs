using Disney.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disney.Application.Contracts.Persistence
{
    public interface IGenreRepository : IAsyncRepository<Genre>
    {
    }
}

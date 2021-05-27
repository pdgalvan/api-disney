using MediatR;
using System;

namespace Disney.Application.Features.Movies.Queries.GetMovieDetail
{
    class GetMovieDetailQuery : IRequest<MovieDetailVm>
    {
        public Guid Id { get; set; }
    }
}

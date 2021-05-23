using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disney.Application.Features.Movies.Queries.GetMovieDetail
{
    class GetMovieDetailQuery : IRequest<MovieDetailVm>
    {
        public Guid Id { get; set; }
    }
}

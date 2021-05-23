using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disney.Application.Features.Movies.Queries.GetMovieList
{
    class GetMovieListQuery : IRequest<List<MovieListVm>>
    {
    }
}

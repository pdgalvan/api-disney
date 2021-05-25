using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disney.Application.Features.Movies.Queries.GetMovieList
{
    public class GetMovieListQuery : IRequest<List<MovieListVm>>
    {
    }
}

using AutoMapper;
using Disney.Application.Features.Characters;
using Disney.Application.Features.Characters.Commands.CreateCharacter;
using Disney.Application.Features.Characters.Commands.UpdateCharacter;
using Disney.Application.Features.Characters.Queries.GetCharacterDetail;
using Disney.Application.Features.Characters.Queries.GetCharacterList;
using Disney.Application.Features.Movies.Commands.CreateMovie;
using Disney.Application.Features.Movies.Queries.GetMovieDetail;
using Disney.Application.Features.Movies.Queries.GetMovieList;
using Disney.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disney.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Character, CharacterListVm>().ReverseMap();
            CreateMap<Character, CharacterDetailVm>().ReverseMap();
            CreateMap<Movie, MovieListVm>().ReverseMap();
            CreateMap<Movie, MovieDetailVm>().ReverseMap();
            CreateMap<Character, CreateCharacterCommand>().ReverseMap();
            CreateMap<Character, UpdateCharacterCommand>().ReverseMap();
            CreateMap<Movie, CreateMovieCommand>().ReverseMap();
            CreateMap<Movie, UpdateCharacterCommand>().ReverseMap();
        }
        
    }
}

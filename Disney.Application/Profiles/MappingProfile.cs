using AutoMapper;
using Disney.Application.Features.Characters;
using Disney.Application.Features.Characters.Queries.GetCharacterDetail;
using Disney.Application.Features.Characters.Queries.GetCharacterList;
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
        }
        
    }
}

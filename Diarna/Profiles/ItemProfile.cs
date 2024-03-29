﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.DTOs.Item;
using Diarna.Data.Domain;

namespace Diarna.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<CreateItemDto, TblItem>();

            CreateMap<TblItem, ReadItemDto>();
            CreateMap<ReadItemDto, TblItem>();

            CreateMap<TblItem, ReadItemDetailDto>()
                .ForMember(dest => dest.ItemTypeName,
                opt => opt.MapFrom(src => src.Itemtype.Name));
        }
    }
}

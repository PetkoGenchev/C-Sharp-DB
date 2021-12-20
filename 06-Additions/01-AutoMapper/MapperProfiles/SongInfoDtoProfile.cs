using AutoMapper;
using Mapping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.MapperProfiles
{
    public class SongInfoDtoProfile : Profile
    {
        public SongInfoDtoProfile()
        {
            this.CreateMap<Song, SongInfoDto>()
               .ForMember(x => x.Artist, options =>
                    options.MapFrom(x =>
                       string.Join(", ", x.SongArtists.Select(a => a.Artist.Name))))
               .ReverseMap();
        }


    }
}

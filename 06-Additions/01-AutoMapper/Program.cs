using _01_AutoMapper.Models;
using AutoMapper;
using System;
using System.Linq;

namespace Mapping
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(config =>
           {
               config.CreateMap<Song, SongInfoDto>();
           });

            var mapper = config.CreateMapper();

            var db = new MusicXContext();
            Song song = db.Songs.Where(x => x.Id == 4).FirstOrDefault();

            var songDto = mapper.Map<SongInfoDto>(song);
        }
    }

    class SongInfoDto
    {
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public string SearchTerms { get; set; }

        public string SourceName { get; set; }
    }


}

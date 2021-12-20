using AutoMapper;
using AutoMapper.QueryableExtensions;
using Mapping.MapperProfiles;
using Mapping.Models;
using System;
using System.Linq;
using System.Text;

namespace Mapping
{
    public class Program
    {

        static void Main(string[] args)
        {
            //Ako iskame Unicode da ni e  konzolata
            Console.OutputEncoding = Encoding.Unicode;



            var config = new MapperConfiguration(config =>
           {
               config.AddProfile(new SongInfoDtoProfile());
           });

            var mapper = config.CreateMapper();

            var db = new MusicXContext();

            Song song = db.Songs.Where(x => x.Id == 4).FirstOrDefault();

            var songDto = mapper.Map<SongInfoDto>(song);


            var songs = db.Songs.Where(x => x.Name.StartsWith("Nik"))
                .ProjectTo<SongInfoDto>(config)
                .ToList();


        }
    }

    class SongInfoDto
    {
        public string Name { get; set; }

        public string Artist { get; set; }

        public DateTime CreatedOn { get; set; }

        public string SearchTerms { get; set; }

        public string SourceName { get; set; }
    }


}

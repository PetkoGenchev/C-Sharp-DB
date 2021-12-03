using System;
using System.Linq;
using TestEFUpdatedVersions.Model;

namespace TestEFUpdatedVersions
{
    public class Program
    {
        static void Main(string[] args)
        {
            var db = new MusicXContext();

            /*
               Console.WriteLine(db.Songs.Count());
               var top10Artists = db.Artists
                   .OrderByDescending(x => x.SongArtists.Count())
                   .Select(x => new { x.Name, Count = x.SongArtists.Count() })
                   .Take(10)
                   .ToList();

               foreach (var artist in top10Artists)
               {
                   Console.WriteLine(artist.Name + " " + artist.Count);
               }
            */



            /*
            var songs = db.Songs
                .Where(x => x.SongArtists.Count() > 5)
                .Select(x => new { x.Name, Artists = string.Join(",", x.SongArtists.Select(a => a.Artist.Name)) })
                .Skip(1)
                .Take(2)
                .ToList();

            foreach (var song in songs)
            {
                Console.WriteLine(song.Name + " => " + song.Artists);
            }
            */



            /*
            var artist = new Artist
            {
                CreatedOn = DateTime.UtcNow,
                Name = "Nakov"
            };


            artist.SongArtists.Add(new SongArtist
            {
                Song = new Song
                {
                    Name = "SoftUni",
                    CreatedOn = DateTime.UtcNow,
                }
            });

            db.Artists.Add(artist);

            db.SaveChanges();
            */


            /*
            var song = db.Songs.OrderByDescending(x => x.Id).FirstOrDefault();

            song.CreatedOn = DateTime.UtcNow;
            */
        }
    }
}

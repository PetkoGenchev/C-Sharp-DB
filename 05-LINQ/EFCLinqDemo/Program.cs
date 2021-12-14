using EFCLinqDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCLinqDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            var db = new MusicXContext();

            var songs = db.Songs
                .Where(x => x.Id <= 10)
                .ToList();

            foreach (var song in songs)
            {
                Console.WriteLine(song.Name);

                Console.WriteLine(song.SongArtists.Count());

                Console.WriteLine(song.Source.Name);
            }
        }
    }
}

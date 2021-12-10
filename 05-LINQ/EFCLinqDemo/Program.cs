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

            var songs = db.Songs.Where(x => x.Name.StartsWith("H")).ToList();

            Console.WriteLine(songs.Count());
        }
    }
}

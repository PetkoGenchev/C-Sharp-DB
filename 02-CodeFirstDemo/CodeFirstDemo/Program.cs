using CodeFirstDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new SlidoDbContext();

            db.Database.Migrate();
        }
    }
}

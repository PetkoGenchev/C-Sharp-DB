using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            var car = new Car
            {
                Extras = new List<string> { "Klimatronik", "4x4", "Farove" },
                ManufacturedOn = DateTime.Now,
                Model = "Golf",
                Vendor = "VW",
                Price = 12345.67M,
                Engine = new Engine { Volume = 1.6M, HorsePower = 80},

            };

            //File.WriteAllText("myCar.json", JsonSerializer.Serialize(car));

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,

            };
            Console.WriteLine(JsonSerializer.Serialize(car,options));
        }
    }
}

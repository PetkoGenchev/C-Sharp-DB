using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XML
{

    public class doc
    {
        public string @abstract { get; set; }

        public string title { get; set; }
    }

    public class Program
    {
    
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.Unicode;
        }
    }
}

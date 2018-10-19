using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LAB08_LINQ.Classes;
using Newtonsoft.Json;

namespace LAB08_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            JsonQueries();
        }

        static void JsonQueries()
        {
            string path = "../../../data.json";
            string text = "";

            using (StreamReader sr = File.OpenText(path))
            {
                text = sr.ReadToEnd();
            }

            var objects = JsonConvert.DeserializeObject<RootObject>(text);

            Console.WriteLine("===========");

            var neighborhoodsInManhatten = objects.features.Select(x => x).Select(x => x.properties.neighborhood);

            foreach(var thing in neighborhoodsInManhatten){
                Console.WriteLine(thing);
            }
        }
    }
}

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

        /// <summary>
        /// This method displays information from a json file using different LINQ queries and lambda statements.
        /// </summary>
        static void JsonQueries()
        {
            string path = "../../../data.json";
            string text = "";

            using (StreamReader sr = File.OpenText(path))
            {
                text = sr.ReadToEnd();
            }

            var data = JsonConvert.DeserializeObject<RootObject>(text);

            Console.WriteLine();
            Console.WriteLine("=========== All Neighborhoods Using Lambda Functions ============");

            //1. Output all of the neighborhoods in this data list
            var neighborhoodsInManhatten = data.features.Select(x => x).Select(x => x.properties.neighborhood);

            foreach(var neighborhood in neighborhoodsInManhatten){
                Console.WriteLine(neighborhood);
            }

            Console.WriteLine();
            Console.WriteLine("=========== All Neighborhoods w/Names Using Lambda Functions ============");

            //2. Filter out all the neighborhoods that do not have any names
            var neighborhoodsNotNullInManhatten = neighborhoodsInManhatten.Select(x => x).Where(x => x != "");

            foreach (var neighborhood in neighborhoodsNotNullInManhatten)
            {
                Console.WriteLine(neighborhood);
            }

            Console.WriteLine();
            Console.WriteLine("=========== All Neighborhoods w/o Duplicates Using Lambda Functions ============");

            //3. Remove the Duplicates
            var neighborhoodsNoDupsInManhatten = neighborhoodsNotNullInManhatten.Select(x => x).Distinct();

            foreach (var neighborhood in neighborhoodsNoDupsInManhatten)
            {
                Console.WriteLine(neighborhood);
            }

            Console.WriteLine();
            Console.WriteLine("=========== Same thing but all chained together ============");

            //4. Remove the Duplicates
            var neighborhoodsChained = data.features.Select(x => x).Select(x => x.properties.neighborhood).Where(x=>x!="").Distinct();

            foreach (var neighborhood in neighborhoodsChained)
            {
                Console.WriteLine(neighborhood);
            }

            Console.WriteLine();
            Console.WriteLine("=========== Same thing but using LINQ ============");

            //5. Remove the Duplicates
            var neighborhoodsWithLINQ = (from neighborhoods in data.features
                                        where neighborhoods.properties.neighborhood != ""
                                        select neighborhoods.properties.neighborhood).Distinct();


            foreach (var neighborhood in neighborhoodsWithLINQ)
            {
                Console.WriteLine(neighborhood);
            }
        }
    }
}

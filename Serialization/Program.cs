using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person
            {
                Id = 1,
                FullName = "П.П. Керсанов",
                Age = 68
            };

            string json = JsonConvert.SerializeObject(person);
            Console.WriteLine(json);

            var result = JsonConvert.DeserializeObject<Person>(json);

            var serializer = new XmlSerializer(typeof(Person));
            using (var stream = File.Create("file2.xml"))
            {
                serializer.Serialize(stream, person);
            }

            using (var stream = File.OpenRead("file2.xml"))
            {
                var result = serializer.Deserialize(stream) as Person;
                Console.WriteLine($"{result.Id}, {result.FullName}, {result.Age}");
                Console.ReadLine();
            }
        }
    }
}

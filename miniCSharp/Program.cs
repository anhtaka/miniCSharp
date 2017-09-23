using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
using System.IO;
using static System.Console;
using System.Runtime.Serialization;

namespace miniCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person();
            p.Name = "keito Ito";
            p.Age = 31;

            using (var ms = new MemoryStream())
            using (var sr = new StreamReader(ms))
            {
                var serializer = new DataContractJsonSerializer(typeof(Person));
                serializer.WriteObject(ms, p);
                ms.Position = 0;

                var json = sr.ReadToEnd();

                WriteLine($"{json}"); // {"Age":31,"Name":"Kato Jun"}
            }

            // var json = JsonConvert.SerializeObject(p);
            //Console.WriteLine($"{json}"); // {"Name":"Kato Jun","Age":31}
            //int i = 0;
            //i = i + 5;
            //Console.WriteLine(i);
        }

        [DataContract]
        public class Person
        {
            [DataMember(Name = "name")]
            public string Name { get; set; }
            [DataMember(Name = "age")]
            public int Age { get; set; }
        }
    }
}

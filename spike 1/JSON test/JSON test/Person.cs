using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JSON_test
{
    class Person
    {
        [JsonPropertyName("alpha")]
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }


        static void Main(string[] args)
        {
            Person person = new Person
            {
                PersonId = 2342,
                FirstName = "Joe",
                LastName = "Paske",
                City = "Platteville"
            };
            var s = JsonSerializer.Serialize(person);
            var obj = JsonSerializer.Deserialize<Person>(s,new JsonSerializerOptions);
        }
    }
}

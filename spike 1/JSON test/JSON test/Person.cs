using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JSON_test
{
    class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }


        static void Main(string[] args)
        {
            using JsonDocument doc = JsonDocument.Parse()
            Console.WriteLine("Hello, welcome to my application!");
            var jsonPath = "JSON_test.JSON_test.testfile.json";
            var jsonStream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(jsonPath);
            string jsonString;
            using (var streamReader = new StreamReader(jsonStream))
            {
                jsonString = streamReader.ReadToEnd();
                Console.WriteLine(jsonString);
            }
            //JsonReadService.ReadJsonFile(AskForJsonFileName(jsonPath));
        }

        public static string AskForJsonFileName(string path)
        {
        BEGIN:
            Console.Write("\nWhat is the name of your JSON file? ");
            var response = path;
            if (File.Exists(response))
            {
                return response;
            }
            else
            {
                Console.Write("\nError: File doesn't exist!");
                goto BEGIN;
            }
        }
    }
}

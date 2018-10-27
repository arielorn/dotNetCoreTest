using Raven.Client;
using Raven.Client.Document;
using System;
using System.Linq;

namespace dotNetCoreTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (IDocumentStore store = new DocumentStore()
            {
                Url =  "http://localhost:8080"
            }.Initialize())
            {
                var session = store.OpenSession(new OpenSessionOptions()
                {
                    Database = "PersonsCore"
                });

                session.Store(new Person
                {
                    FirstName = "Ariel",
                    LastName = "Ornstein"
                });

                session.SaveChanges();
                var person = session.Query<Person>().ToList();

            }
        }
    }

    public class Person
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

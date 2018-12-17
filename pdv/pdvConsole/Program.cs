using Microsoft.EntityFrameworkCore;
using pdvInfraestrutura.Database;
using pdvInfraestrutura.Model;
using System;
using System.Collections.Generic;

namespace pdvConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new pdvContext())
            {
                //context.Database.EnsureCreated();
                context.Database.Migrate();
            }

            Console.WriteLine("Database!");

            Console.ReadKey();

            using (var context = new pdvContext())
            {
                var author = new Author
                {
                    FirstName = "William",
                    LastName = "Shakespeare",
                    Books = new List<Book>
                    {
                        new Book { Title = "Hamlet"},
                        new Book { Title = "Othello" },
                        new Book { Title = "MacBeth" }
                    }
                };
                context.Add(author);
                context.SaveChanges();
            }

            Console.WriteLine("Save!");

            Console.ReadKey();

            using (var context = new pdvContext())
            {
                foreach (var book in context.Books)
                {
                    Console.WriteLine(book.Title);
                }
            }

            Console.WriteLine("Lista!");

            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
    }
}

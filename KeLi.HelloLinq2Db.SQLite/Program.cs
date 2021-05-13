using System;
using System.Linq;

using DataModels;

using KeLi.HelloLinq2Db.SQLite.TableModels;

using LinqToDB;

namespace KeLi.HelloLinq2Db.SQLite
{
    internal class Program
    {
        private static void Main()
        {
            using (var context = new MyDatabaseDB())
            {
                // Add data.
                {
                    context.Insert(new Person { FirstName = "Tom", LastName = "Smith", MiddleName = "Haha" });
                    context.Insert(new Person { FirstName = "Tony", LastName = "Miller", MiddleName = "Dodo" });
                    context.Insert(new Person { FirstName = "Jack", LastName = "Johnson", MiddleName = "wawa" });

                    Console.WriteLine("After Added data:");

                    foreach (var item in context.People.ToList())
                        Console.WriteLine(item.FirstName);
                }

                Console.WriteLine();

                // Delete data.
                {
                    var peroson = context.People.FirstOrDefault(f => f.FirstName.Contains("Tom"));

                    context.Delete(peroson);

                    Console.WriteLine("After Deleted data:");

                    foreach (var item in context.People.ToList())
                        Console.WriteLine(item.FirstName);
                }

                Console.WriteLine();

                // Update data.
                {
                    var peroson = context.People.FirstOrDefault(w => w.FirstName.Contains("Jack"));

                    if (peroson != null)
                        peroson.FirstName = "Alice";

                    context.Update(peroson);

                    Console.WriteLine("After Updated data:");

                    foreach (var item in context.People.ToList())
                        Console.WriteLine(item.FirstName);
                }

                Console.WriteLine();

                // Query data.
                {
                    var people = context.People.Where(w => w.FirstName.Contains("T"));

                    Console.WriteLine("Query data:");

                    foreach (var item in people)
                        Console.WriteLine(item.FirstName);
                }
            }

            Console.ReadKey();
        }
    }
}

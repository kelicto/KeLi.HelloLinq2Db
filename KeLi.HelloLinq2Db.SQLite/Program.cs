using System;
using System.Linq;

using KeLi.HelloLinq2Db.SQLite.Utils;

using Models;

namespace KeLi.HelloLinq2Db.SQLite
{
    internal class Program
    {
        private static void Main()
        {
            var helper = new DbHelper();

            // Add data.
            {
                helper.Insert(new Student { Name = "Tom" });
                helper.Insert(new Student { Name = "Jack" });
                helper.Insert(new Student { Name = "Tony" });

                Console.WriteLine("After Added data:");

                foreach (var item in helper.QueryList(q => q.Students.ToList()))
                    Console.WriteLine(item.Name);
            }

            Console.WriteLine();

            // Delete data.
            {
                helper.Delete(q => q.Students.FirstOrDefault(f => f.Name.Contains("Tom")));

                Console.WriteLine("After Deleted data:");

                foreach (var item in helper.QueryList(q => q.Students.ToList()))
                    Console.WriteLine(item.Name);
            }

            Console.WriteLine();

            // Update data.
            {
                helper.Update(s => s.Name = "Alice", q => q.Students.FirstOrDefault(f => f.Name.Contains("Jack")));

                Console.WriteLine("After Updated data:");

                foreach (var item in helper.QueryList(q => q.Students.ToList()))
                    Console.WriteLine(item.Name);
            }

            Console.WriteLine();

            // Query data.
            {
                var students = helper.QueryList(q => q.Students.Where(w => w.Name.Contains("T")).ToList());

                Console.WriteLine("Query data:");

                foreach (var item in students)
                    Console.WriteLine(item.Name);
            }

            Console.ReadKey();
        }
    }
}
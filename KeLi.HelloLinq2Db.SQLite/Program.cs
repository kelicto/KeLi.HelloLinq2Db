using System;
using System.Linq;

using DataModels;

using KeLi.HelloLinq2Db.SQLite.Extensions;

namespace KeLi.HelloLinq2Db.SQLite
{
    internal class Program
    {
        private static void Main()
        {
            // Add data.
            {
                DbUtil.Insert(new Student { Name = "Tom" });
                DbUtil.Insert(new Student { Name = "Jack" });
                DbUtil.Insert(new Student { Name = "Tony" });

                Console.WriteLine("After Added data:");

                foreach (var item in DbUtil.QueryList(q => q.Students.ToList()))
                    Console.WriteLine(item.Name);
            }

            Console.WriteLine();

            // Delete data.
            {
                var student = DbUtil.Query(q => q.Students.FirstOrDefault(f => f.Name.Contains("Tom")));

                if (student != null)
                    DbUtil.Delete(student);

                Console.WriteLine("After Deleted data:");

                foreach (var item in DbUtil.QueryList(q => q.Students.ToList()))
                    Console.WriteLine(item.Name);
            }

            Console.WriteLine();

            // Update data.
            {
                var student = DbUtil.Query(q => q.Students.FirstOrDefault(f => f.Name.Contains("Jack")));

                if (student != null)
                    student.Name = "Alice";

                DbUtil.Update(student);

                Console.WriteLine("After Updated data:");

                foreach (var item in DbUtil.QueryList(q => q.Students.ToList()))
                    Console.WriteLine(item.Name);
            }

            Console.WriteLine();

            // Query data.
            {
                var students = DbUtil.QueryList(q => q.Students.Where(w => w.Name.Contains("T")).ToList());

                Console.WriteLine("Query data:");

                foreach (var item in students)
                    Console.WriteLine(item.Name);
            }

            Console.ReadKey();
        }
    }
}
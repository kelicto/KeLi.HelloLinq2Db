using System.Linq;

using DataModels;

using LinqToDB;

namespace KeLi.HelloLinq2Db.SQLite.TableModels
{
    public static class TableExtensions
    {
        public static Person Find(this ITable<Person> table, long PersonId)
        {
            return table.FirstOrDefault(t => t.PersonId == PersonId);
        }
    }
}
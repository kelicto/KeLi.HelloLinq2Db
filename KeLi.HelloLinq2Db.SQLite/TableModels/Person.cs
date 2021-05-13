using LinqToDB.Mapping;

namespace KeLi.HelloLinq2Db.SQLite.TableModels
{
    [Table("Person")]
    public partial class Person
    {
        [PrimaryKey, Identity] public long   PersonId   { get; set; } // integer
        [Column,     NotNull ] public string FirstName  { get; set; } // nvarchar(50)
        [Column,     NotNull ] public string LastName   { get; set; } // nvarchar(50)
        [Column,     NotNull ] public string MiddleName { get; set; } // nvarchar(50)
        [Column,     NotNull ] public char   Gender     { get; set; } // char(1)
    }
}
//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by T4Model template for T4 (https://github.com/linq2db/linq2db).
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------

#pragma warning disable 1591

using System;
using System.Linq;

using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Mapping;

namespace Models
{
	/// <summary>
	/// Database       : MyDatabase
	/// Data Source    : MyDatabase
	/// Server Version : 3.24.0
	/// </summary>
	public partial class MyDatabaseDB : LinqToDB.Data.DataConnection
	{
		public ITable<Student> Students { get { return this.GetTable<Student>(); } }

		public MyDatabaseDB()
		{
			InitDataContext();
			InitMappingSchema();
		}

		public MyDatabaseDB(string configuration)
			: base(configuration)
		{
			InitDataContext();
			InitMappingSchema();
		}

		public MyDatabaseDB(LinqToDbConnectionOptions options)
			: base(options)
		{
			InitDataContext();
			InitMappingSchema();
		}

		partial void InitDataContext  ();
		partial void InitMappingSchema();
	}

	[Table("Student")]
	public partial class Student
	{
		[PrimaryKey, Identity   ] public long   Id      { get; set; } // integer
		[Column,     NotNull    ] public string Name    { get; set; } // nvarchar(50)
		[Column,        Nullable] public string Email   { get; set; } // nvarchar(50)
		[Column,        Nullable] public string Address { get; set; } // nvarchar(50)
		[Column,        Nullable] public string Remark  { get; set; } // nvarchar(50)
	}

	public static partial class TableExtensions
	{
		public static Student Find(this ITable<Student> table, long Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}
	}
}

#pragma warning restore 1591

namespace KeLi.HelloLinq2Db.SQLite.Models
{
    public abstract class BaseRecord
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Remark { get; set; }
    }
}

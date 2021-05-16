using System;
using System.Collections.Generic;

using DataModels;

using KeLi.HelloLinq2Db.SQLite.Properties;

using LinqToDB;
using LinqToDB.Configuration;

namespace KeLi.HelloLinq2Db.SQLite.Utils
{
    public class DbUtil
    {
        public static int Insert<T>(T entity) where T : class
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            var options = GetOptions();

            using (var connection = new MyDatabaseDataConnection(options))
                return connection.Insert(entity);
        }

        public static int Delete<T>(Func<MyDatabaseDataConnection, T> func) where T : class
        {
            if (func is null)
                throw new ArgumentNullException(nameof(func));

            var options = GetOptions();

            using (var connection = new MyDatabaseDataConnection(options))
            {
                var target = func.Invoke(connection);

                if (target is null)
                    return 0;

                return connection.Delete(target);
            }
        }

        public static int Update<T>(Func<MyDatabaseDataConnection, T> func, Action<T> action) where T : class
        {
            if (func is null)
                throw new ArgumentNullException(nameof(func));

            if (action is null)
                throw new ArgumentNullException(nameof(action));

            var options = GetOptions();

            using (var connection = new MyDatabaseDataConnection(options))
            {
                var target = func.Invoke(connection);

                if (target is null)
                    return 0;

                action.Invoke(target);

                return connection.Update(target);
            }
        }

        public static T Query<T>(Func<MyDatabaseDataConnection, T> func) where T : class
        {
            if (func is null)
                throw new ArgumentNullException(nameof(func));

            var options = GetOptions();

            using (var connection = new MyDatabaseDataConnection(options))
                return func.Invoke(connection);
        }

        public static List<T> QueryList<T>(Func<MyDatabaseDataConnection, List<T>> func) where  T : class 
        {
            if (func is null)
                throw new ArgumentNullException(nameof(func));

            var options = GetOptions();

            using (var connection = new MyDatabaseDataConnection(options))
                return func.Invoke(connection);
        }

        private static LinqToDbConnectionOptions GetOptions()
        {
            var builder = new LinqToDbConnectionOptionsBuilder();

            builder.UseConnectionString(Resources.ProviderName, Resources.ConnectionString);

            return new LinqToDbConnectionOptions(builder);
        }
    }
}

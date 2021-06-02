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
        public static int Insert<T>(T entity, Func<MyDatabaseDataConnection, T> finder = null) where T : class
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            var options = GetOptions();

            using (var connection = new MyDatabaseDataConnection(options))
            {
                if(finder is null)
                    return connection.Insert(entity);

                var target = finder.Invoke(connection);

                if (target is null)
                    return connection.Insert(entity);

                return 0;
            }
        }

        public static int Delete<T>(Func<MyDatabaseDataConnection, T> finder) where T : class
        {
            if (finder is null)
                throw new ArgumentNullException(nameof(finder));

            var options = GetOptions();

            using (var connection = new MyDatabaseDataConnection(options))
            {
                var target = finder.Invoke(connection);

                if (target is null)
                    return 0;

                return connection.Delete(target);
            }
        }

        public static int Update<T>(Action<T> action, Func<MyDatabaseDataConnection, T> finder) where T : class
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));

            var options = GetOptions();

            using (var connection = new MyDatabaseDataConnection(options))
            {
                var target = finder.Invoke(connection);

                if (target is null)
                    return 0;

                action.Invoke(target);

                return connection.Update(target);
            }
        }

        public static T Query<T>(Func<MyDatabaseDataConnection, T> finder) where T : class
        {
            if (finder is null)
                throw new ArgumentNullException(nameof(finder));

            var options = GetOptions();

            using (var connection = new MyDatabaseDataConnection(options))
                return finder.Invoke(connection);
        }

        public static List<T> QueryList<T>(Func<MyDatabaseDataConnection, List<T>> finder) where  T : class 
        {
            if (finder is null)
                throw new ArgumentNullException(nameof(finder));

            var options = GetOptions();

            using (var connection = new MyDatabaseDataConnection(options))
                return finder.Invoke(connection);
        }

        private static LinqToDbConnectionOptions GetOptions()
        {
            var builder = new LinqToDbConnectionOptionsBuilder();

            builder.UseConnectionString(Resources.ProviderName, Resources.ConnectionString);

            return new LinqToDbConnectionOptions(builder);
        }
    }
}

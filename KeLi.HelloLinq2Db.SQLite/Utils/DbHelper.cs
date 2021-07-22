using System;
using System.Collections.Generic;

using KeLi.HelloLinq2Db.SQLite.Properties;

using LinqToDB;
using LinqToDB.Configuration;

using Models;

namespace KeLi.HelloLinq2Db.SQLite.Utils
{
    public class DbHelper
    {
        public int InsertOrUpdate<T>(T entity, Action<T> updater, Func<MyDatabaseDB, T> finder) where T : class
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            if (updater is null)
                throw new ArgumentNullException(nameof(updater));

            if (finder is null)
                throw new ArgumentNullException(nameof(finder));

            var options = GetOptions();

            using (var connection = new MyDatabaseDB(options))
            {
                var target = finder.Invoke(connection);

                if (target is null)
                    return connection.Insert(entity);

                updater.Invoke(target);

                return connection.Update(target);
            }
        }

        public int Insert<T>(T entity, Func<MyDatabaseDB, T> finder = null) where T : class
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            var options = GetOptions();

            using (var connection = new MyDatabaseDB(options))
            {
                if (finder is null)
                    return connection.Insert(entity);

                var target = finder.Invoke(connection);

                if (target is null)
                    return connection.Insert(entity);

                return 0;
            }
        }

        public int Delete<T>(Func<MyDatabaseDB, T> finder) where T : class
        {
            if (finder is null)
                throw new ArgumentNullException(nameof(finder));

            var options = GetOptions();

            using (var connection = new MyDatabaseDB(options))
            {
                var target = finder.Invoke(connection);

                if (target is null)
                    return 0;

                return connection.Delete(target);
            }
        }

        public int Update<T>(Action<T> updater, Func<MyDatabaseDB, T> finder) where T : class
        {
            if (updater is null)
                throw new ArgumentNullException(nameof(updater));

            if (finder is null)
                throw new ArgumentNullException(nameof(finder));

            var options = GetOptions();

            using (var connection = new MyDatabaseDB(options))
            {
                var target = finder.Invoke(connection);

                if (target is null)
                    return 0;

                updater.Invoke(target);

                return connection.Update(target);
            }
        }

        public T Query<T>(Func<MyDatabaseDB, T> finder) where T : class
        {
            if (finder is null)
                throw new ArgumentNullException(nameof(finder));

            var options = GetOptions();

            using (var connection = new MyDatabaseDB(options))
                return finder.Invoke(connection);
        }

        public List<T> QueryList<T>(Func<MyDatabaseDB, List<T>> finder) where T : class
        {
            if (finder is null)
                throw new ArgumentNullException(nameof(finder));

            var options = GetOptions();

            using (var connection = new MyDatabaseDB(options))
                return finder.Invoke(connection);
        }

        private LinqToDbConnectionOptions GetOptions()
        {
            var builder = new LinqToDbConnectionOptionsBuilder();

            builder.UseConnectionString(Resources.ProviderName, Resources.ConnectionString);

            return new LinqToDbConnectionOptions(builder);
        }
    }
}
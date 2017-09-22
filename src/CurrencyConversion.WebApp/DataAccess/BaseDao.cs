using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using Dapper;
using DapperExtensions.Sql;

namespace CurrencyConversion.WebApp.DataAccess
{
    public class BaseDao
    {
        protected readonly string DbFilePath;

        public BaseDao()
        {
            DbFilePath = $"{HostingEnvironment.ApplicationPhysicalPath}currency-db.sqlite";
            DapperExtensions.DapperExtensions.SqlDialect = new SqliteDialect();
        }

        protected string ConnectionString => $"Data Source={DbFilePath};Version=3;";

        private DbConnection Connection
        {
            get
            {
                if (!File.Exists(DbFilePath))
                {
                    SQLiteConnection.CreateFile(DbFilePath);

                    Execute(Sql.Scripts.CreateSchema);
                    Execute(Sql.Scripts.FillData);
                }

                return new SQLiteConnection(ConnectionString);
            }
        }

        protected IList<T> Query<T>(string sql, object parameters = null)
        {
            IList<T> result;

            using (var connection = Connection)
            {
                connection.Open();
                result = connection.Query<T>(sql, parameters).ToList();
                connection.Close();
            }

            return result;
        }

        protected void Execute(string sql, object parameters = null)
        {
            using (var connection = Connection)
            {
                connection.Open();
                connection.Execute(sql, parameters);
                connection.Close();
            }
        }
    }
}

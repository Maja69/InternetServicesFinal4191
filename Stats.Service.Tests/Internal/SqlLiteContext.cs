using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using midTerm.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stats.Service.Tests.Internal
{
    public class SQLiteDbContext : IDisposable
    {
        private DbConnection _connection;

        private DbContextOptions<MidTermDbContext> CreateOptions()
        {
            return new DbContextOptionsBuilder<MidTermDbContext>()
                .UseSqlite(_connection)
                .Options;
        }

        public MidTermDbContext CreateContext()
        {
            if (_connection == null)
            {
                _connection = new SqliteConnection("DataSource=:memory:");
                _connection.Open();

                var options = CreateOptions();
                using var context = new MidTermDbContext(options);
                context.Database.EnsureCreated();
            }

            return new MidTermDbContext(CreateOptions());
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}

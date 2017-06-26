using Artemis.Common;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Data
{
    public class CarAdvertDbContext : DbContext
    {
        public CarAdvertDbContext() : base("SqlConnectionString")
        {

        }

        public CarAdvertDbContext(DbConnection connection, bool contextOwnsConnection) 
            : base(connection, contextOwnsConnection)
        {

        }

        static CarAdvertDbContext()
        {
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
            if (type == null)
                throw new Exception("Do not remove, ensures static reference to System.Data.Entity.SqlServer");

            type = typeof(System.Data.SQLite.SQLiteContext);
            if (type == null)
                throw new Exception("Do not remove, ensures static reference to SQLite");

            type = typeof(System.Data.SQLite.EF6.SQLiteProviderFactory);
            if (type == null)
                throw new Exception("Do not remove, ensures static reference to SQLite");

            type = typeof(System.Data.SQLite.Linq.SQLiteProviderFactory);
            if (type == null)
                throw new Exception("Do not remove, ensures static reference to SQLite");
        }

        public DbSet<CarAdvert> CarAdverts { get; set; }
    }
}

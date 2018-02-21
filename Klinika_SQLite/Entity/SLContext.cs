using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika_SQLite.Entity
{
        public class SLContext : DbContext
        {
            public SLContext() : base("MyConnection")
            {

            }
            public DbSet<Person> Persons { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                var sqliteConnectionInitializer =
                    new SqliteCreateDatabaseIfNotExists<SLContext>(modelBuilder);
                Database.SetInitializer(sqliteConnectionInitializer);
            }
        }
        public class Person
        {
            [Key]
            public int Id { get; set; }
            [Required, StringLength(maximumLength: 250)]
            public string Name { get; set; }
        }
    
}

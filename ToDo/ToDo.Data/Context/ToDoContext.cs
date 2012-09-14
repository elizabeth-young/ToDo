using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;

namespace ToDo.Data.Context
{
    public class ToDoContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ToDoContext(string nameOrConnection) : base(nameOrConnection) { }
        public ToDoContext() : base("ToDo") { }

        public static void InitialiseDatabase(IDatabaseInitializer<ToDoContext> initialiser)
        {
            Database.SetInitializer(initialiser);
            new ToDoContext().Database.Initialize(true);
        }

        public static void InitialiseDatabase(string dbName, IDatabaseInitializer<ToDoContext> initialiser)
        {
            Database.SetInitializer(initialiser);
            new ToDoContext(dbName).Database.Initialize(true);
        }

        protected override void  OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

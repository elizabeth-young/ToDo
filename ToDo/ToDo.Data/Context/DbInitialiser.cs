using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace ToDo.Data.Context
{
    public class EmptyDbInitialiser : DropCreateDatabaseAlways<ToDoContext>
    {
        protected override void Seed(ToDoContext context)
        {
            base.Seed(context);
            context.SaveChanges();
        }
    }
    public class ToDoInitialiser : CreateDatabaseIfNotExists<ToDoContext>
    //public class ToDoInitialiser : MigrateDatabaseToLatestVersion<ToDoContext, Migrations.Configuration>
    {
        protected override void Seed(ToDoContext context)
        {
            context.SaveChanges();
            base.Seed(context);
        }
    }
}

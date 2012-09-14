using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDo.Data.Context
{
    public interface IToDoContextProvider
    {
        ToDoContext DataContext { get; }
    }
    public class ToDoContextProvider : IToDoContextProvider
    {
        public ToDoContext DataContext { get; private set; }

        public ToDoContextProvider(string dbName)
        {
            DataContext = String.IsNullOrEmpty(dbName) ? new ToDoContext() : new ToDoContext(dbName);
        }
    }
}

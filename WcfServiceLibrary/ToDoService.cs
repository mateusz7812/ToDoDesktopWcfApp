using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ToDoLibrary;

namespace WcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.

    public class ToDoService : IToDoService
    {
        public bool AddToDo(ToDo todo)
        {
            if (todo.Name is null)
                return false;
            ToDoDB.ToDos.Add(todo);
            Console.WriteLine("Todo added");
            return true;
        }

        public bool DeleteToDo(int index)
        {
            if (index < 0 || index >= ToDoDB.ToDos.Count)
                return false;
            ToDoDB.ToDos.RemoveAt(index);
            Console.WriteLine("Todo deleted");
            return true;
        }

        public string GetToDoDescription(int index)
        {
            if (index < 0 || index >= ToDoDB.ToDos.Count)
                return null;
            Console.WriteLine("Todo description readed");
            return ToDoDB.ToDos [index].Description;
        }


        public bool MarkToDoCompleted(int index)
        {
            if (index < 0 || index >= ToDoDB.ToDos.Count)
                return false;
            ToDoDB.ToDos [index].Completed = true;
            Console.WriteLine("Todo completed");
            return true;
        }
    }

}

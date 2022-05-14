using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ToDoService : IToDoService
    {
        private static readonly List<ToDo> ToDos = new List<ToDo>();
        public bool AddToDo(ToDo todo)
        {
            if (todo.Name is null)
                return false;
            ToDos.Add(todo);
            return true;
        }

        public bool DeleteToDo(int index)
        {
            if (index < 0 || index >= ToDos.Count)
                return false;
            ToDos.RemoveAt(index);
            return true;
        }

        public string GetToDoDescription(int index)
        {
            if (index < 0 || index >= ToDos.Count)
                return null;
            return ToDos [index].Description;
        }

        public List<ToDo> GetToDos(string search)
        {
            return ToDos.Where(
                    todo => search is null || 
                    todo.Name.Contains(search) || 
                    todo.Description.Contains(search)
                ).ToList();
        }

        public bool MarkToDoCompleted(int index)
        {
            if (index < 0 || index >= ToDos.Count)
                return false;
            ToDos [index].Completed = true;
            return true;
        }
    }
}

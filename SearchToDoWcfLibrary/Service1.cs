using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using ToDoLibrary;

namespace SearchToDoWcfLibrary
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class SearchToDoService : ISearchToDoService
    {
        ISearchCallback callback = null;
        public SearchToDoService()
        {
            callback = OperationContext.Current.GetCallbackChannel<ISearchCallback>();
        }

        public void GetToDos(string search)
        {
            Console.WriteLine("Todo searching");
            Thread.Sleep(2000);
            callback.SearchResult(ToDoDB.ToDos.Where(
                    todo => search is null ||
                    todo.Name.Contains(search) ||
                    todo.Description.Contains(search)
                ).ToList());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ToDoLibrary;

namespace SearchToDoWcfLibrary
{

    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(ISearchCallback))]
    public interface ISearchToDoService
    {
        [OperationContract(IsOneWay = true)]
        void GetToDos(string search);
    }

    public interface ISearchCallback
    {
        [OperationContract(IsOneWay = true)]
        void SearchResult(List<ToDo> result);
    }
}


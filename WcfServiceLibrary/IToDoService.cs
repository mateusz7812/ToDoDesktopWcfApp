using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ToDoLibrary;

namespace WcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IToDoService
    {
        [OperationContract]
        bool AddToDo(ToDo todo);
        
        [OperationContract]
        bool MarkToDoCompleted(int index);

        [OperationContract]
        bool DeleteToDo(int index);

        [OperationContract]
        string GetToDoDescription(int index);


        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WcfServiceLibrary.ContractType".
    
}

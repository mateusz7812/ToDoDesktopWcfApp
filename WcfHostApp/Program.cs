using SearchToDoWcfLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary;

namespace WcfHostApp
{
    class Program
    {
        static void Main(string [] args)
        {
            Uri baseAddress1 = new Uri("http://localhost:10000/ToDoService");
            ServiceHost myHost1 = new ServiceHost(typeof(ToDoService), baseAddress1);
            BasicHttpBinding myBinding1 = new BasicHttpBinding();
            ServiceEndpoint endpoint1 = myHost1.AddServiceEndpoint(typeof(IToDoService), myBinding1, "endpoint1");

            Uri baseAddress2 = new Uri("http://localhost:10000/SearchService");
            ServiceHost myHost3 = new ServiceHost(typeof(SearchToDoService), baseAddress2);
            WSDualHttpBinding myBinding3 = new WSDualHttpBinding(WSDualHttpSecurityMode.None);
            ServiceEndpoint endpoint3 = myHost3.AddServiceEndpoint(typeof(ISearchToDoService), myBinding3, "endpoint3");

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            myHost1.Description.Behaviors.Add(smb);
            myHost3.Description.Behaviors.Add(smb);

            try
            {
                myHost1.Open();
                myHost3.Open();
                Console.WriteLine("--> ToDoService is running.");
                Console.WriteLine("--> Press <ENTER> to stop.\n");
                Console.ReadLine(); //wait for stop
                myHost1.Close();
                myHost3.Close();
                Console.WriteLine("--> ToDoService finished");
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("Exception occurred: {0}", ce.Message);
                myHost1.Abort();
                myHost3.Abort();
            }

            Console.ReadLine(); //wait for stop
        }
    }
}

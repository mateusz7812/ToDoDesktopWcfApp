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

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            myHost1.Description.Behaviors.Add(smb);

            try
            {
                myHost1.Open();
                Console.WriteLine("--> ToDoService is running.");
                Console.WriteLine("--> Press <ENTER> to stop.\n");
                Console.ReadLine(); //wait for stop
                myHost1.Close();
                Console.WriteLine("--> ToDoService finished");
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("Exception occurred: {0}", ce.Message);
                myHost1.Abort();
            }

            Console.ReadLine(); //wait for stop
        }
    }
}

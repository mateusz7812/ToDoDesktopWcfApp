using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfClientApp.ToDoService;

namespace WpfClientApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IToDoService client1;
        public MainWindow()
        {
            InitializeComponent();
            InitializeWcf();
        }

        private void InitializeWcf()
        {
            Uri baseAddress = new Uri("http://localhost:10000/ToDoService/endpoint1");
            BasicHttpBinding myBinding = new BasicHttpBinding();
            EndpointAddress eAddress = new EndpointAddress(baseAddress);

            ChannelFactory<IToDoService> myCF = new ChannelFactory<IToDoService>(myBinding, eAddress);

            client1 = myCF.CreateChannel();
        }
    }
}

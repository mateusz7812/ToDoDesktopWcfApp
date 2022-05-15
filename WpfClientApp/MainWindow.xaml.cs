using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using WpfClientApp.ServiceReference1;

namespace WpfClientApp
{
    public partial class MainWindow : Window
    {
        private ChannelFactory<IToDoService> myCF;
        private IToDoService client1;

        private DuplexChannelFactory<ServiceReference2.ISearchToDoService> myCF3;
        private ServiceReference2.ISearchToDoService client3;

        public MainWindow()
        {
            InitializeComponent();
            InitializeWcf();
        }
        ~MainWindow()
        {
            client1 = null;
            myCF.Close();
            client3 = null;
            myCF3.Close();
        }

        private void InitializeWcf()
        {
            Uri baseAddress = new Uri("http://localhost:10000/ToDoService/endpoint1");
            BasicHttpBinding myBinding = new BasicHttpBinding();
            EndpointAddress eAddress = new EndpointAddress(baseAddress);
            myCF = new ChannelFactory<IToDoService>(myBinding, eAddress);
            client1 = myCF.CreateChannel();

            Uri baseAddress3 = new Uri("http://localhost:10000/SearchService/endpoint3");
            WSDualHttpBinding myBinding3 = new WSDualHttpBinding(WSDualHttpSecurityMode.None);
            EndpointAddress eAddress3 = new EndpointAddress(baseAddress3);
            SearchCallback myCbHandler = new SearchCallback(DisplayToDos);
            InstanceContext instanceContext = new InstanceContext(myCbHandler);
            myCF3 = new DuplexChannelFactory<ServiceReference2.ISearchToDoService>(typeof(SearchCallback), myBinding3, eAddress3);
            client3 = myCF3.CreateChannel(instanceContext);

            AddTestTodos();
        }


        private void AddTestTodos()
        {
            ToDo todo = new ToDo();
            todo.Name = "test1";
            todo.Description = "testDescription";
            todo.Deadline = DateTime.Now;
            todo.Completed = true;
            todo.Rating = 3;
            AddToDo(todo);
        }

        private void AddToDo(ToDo todo)
        {
            client1.AddToDo(todo);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddingWindow win2 = new AddingWindow(AddToDo);
            win2.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            client3.GetToDos(SearchBox.Text);
        }

        private void DisplayToDos(ServiceReference2.ToDo [] toDos)
        {
            todo_list.Children.Clear();
            foreach (var todo in toDos)
            {
                AddToDoToList(todo);
            }
        }

        private void AddToDoToList(ServiceReference2.ToDo todo)
        {
            var index = todo_list.Children.Count;
            StackPanel stack = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };

            TextBlock name = new TextBlock
            {
                Text = todo.Name,
                Margin = new Thickness(5)
            };
            stack.Children.Add(name);

            TextBlock deadline = new TextBlock
            {
                Text = todo.Deadline.ToString(),
                Margin = new Thickness(5)
            };
            stack.Children.Add(deadline);

            TextBlock rating = new TextBlock
            {
                Text = todo.Rating.ToString(),
                Margin = new Thickness(5)
            };
            stack.Children.Add(rating);

            TextBlock completed = new TextBlock
            {
                Text = todo.Completed ? "Completed" : "Not completed",
                Margin = new Thickness(5)
            };
            stack.Children.Add(completed);

            Button completeButton = new Button()
            {
                Content = "Complete",
                Visibility = todo.Completed ? Visibility.Hidden : Visibility.Visible,
                Margin = new Thickness(5, 2, 5, 2)
            };
            completeButton.Click += new RoutedEventHandler((object x, RoutedEventArgs args) => { client1.MarkToDoCompleted(index); Refresh(); });
            stack.Children.Add(completeButton);

            Button deleteButton = new Button()
            {
                Content = "Remove",
                Margin = new Thickness(5, 2, 5, 2)
            };
            deleteButton.Click += new RoutedEventHandler((object x, RoutedEventArgs args) => { client1.DeleteToDo(index); Refresh(); });
            stack.Children.Add(deleteButton);
            stack.AddHandler(
                MouseUpEvent,
                new RoutedEventHandler(
                    (object x, RoutedEventArgs args) =>
                        new DescriptionWindow(
                            todo.Name,
                            client1.GetToDoDescription(index)
                        ).ShowDialog()
                )
            );
            todo_list.Children.Add(stack);
        }
    }
}

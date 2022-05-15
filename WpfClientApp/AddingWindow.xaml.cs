using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfClientApp.ServiceReference1;

namespace WpfClientApp
{
    /// <summary>
    /// Interaction logic for AddingWindow.xaml
    /// </summary>
    public partial class AddingWindow : Window
    {
        public Action<ToDo> AddToDo;

        public AddingWindow(Action<ToDo> addToDo)
        {
            InitializeComponent();
            AddToDo = addToDo;
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ToDo todo = new ToDo();
            todo.Name = NameBox.Text;
            todo.Description = DescriptionBox.Text;
            todo.Deadline = DeadlineBox.DisplayDate;
            todo.Completed = false;
            todo.Rating = int.Parse(RatingBox.Text);
            AddToDo(todo);
            Close();
        }
    }
}

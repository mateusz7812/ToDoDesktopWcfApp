﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfClientApp
{
    /// <summary>
    /// Interaction logic for DescriptionWindow.xaml
    /// </summary>
    public partial class DescriptionWindow : Window
    {
        public DescriptionWindow(string name, string description)
        {
            InitializeComponent();
            NameBox.Text = name;
            DescriptionBox.Text = description;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

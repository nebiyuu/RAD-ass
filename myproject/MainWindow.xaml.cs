using System;
using System.Windows;
using System.Windows.Controls;
using Azure;
using System.Windows.Navigation;
using Microsoft.Data.SqlClient;

namespace myproject
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Navigate to Page1
            MainFrame.Navigate(new Page1());

        }

    }   
}

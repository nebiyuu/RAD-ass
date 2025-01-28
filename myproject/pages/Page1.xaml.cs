using System;
using System.Windows;
using System.Windows.Controls;
using myproject.Classes;
using myproject.pages;

namespace myproject
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string userID = Username.Text;
            string password = Password.Text;

            // Create a Student object
            Student student = new Student(userID, password);

            try
            {
                // Authenticate the student
                bool isAuthenticated = student.Authenticate();

                if (isAuthenticated)
                {
                    // Navigate to Page2 on successful login
                    this.NavigationService.Navigate(new Page2());
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
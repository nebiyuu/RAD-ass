using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using myproject.Classes; 



namespace myproject.pages
{
    public partial class Page3 : Page
    {
        public Page3(Exam exam)
        {
            InitializeComponent();
            Popup(exam);
            // Set the exam details to display
            ExamNameTextBlock.Text = exam.Name;
            ExamIdTextBlock.Text = exam.ExamId;
            ExamtimeTextBlock.Text = exam.Time;
            ExamquestionsTextBlock.Text = exam.NumberOfQuestions;

        }

      

        private void Popup(Exam exam)
        {
            // MessageBox.Show("are you ready to start the exam!", "are you ready to start the exam!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page4());

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page2());

        }
    }
}


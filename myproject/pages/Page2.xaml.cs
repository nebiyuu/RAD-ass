using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Azure;
using Microsoft.Data.SqlClient;
using myproject.Classes;  // This ensures access to the Exam class



namespace myproject.pages
{
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string queryforexams = "SELECT exam_id, exam_name, number_of_questions, time FROM exams";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(queryforexams, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    var exams = new List<Exam>();
                    while (reader.Read())
                    {
                        exams.Add(new Exam
                        {
                            Name = reader["exam_name"].ToString(),
                            ExamId = reader["exam_id"].ToString(),
                            NumberOfQuestions = reader["number_of_questions"].ToString(),
                            Time = reader["time"].ToString() // Change if needed based on your DB type
                        });
                    }


                    ExamsListView.ItemsSource = exams;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ExamsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ExamsListView.SelectedItem is Exam selectedExam)
            {
                // Navigate to another page, passing the selected exam data
                NavigationService.Navigate(new Page3(selectedExam));
            }
        }

      
    }
}

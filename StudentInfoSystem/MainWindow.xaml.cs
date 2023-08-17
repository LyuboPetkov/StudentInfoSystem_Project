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
using System.Data;
using System.Data.SqlClient;
using UserLogin;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillStudStatusChoices();
            CmBoxStatus.ItemsSource = StudStatusChoices;
            if (TestStudentsIfEmpty() == true)
            {
                CopyTestStudents();
            }            
        }

        public List<string> StudStatusChoices { get; set; }

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new
            SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery =
                @"SELECT StatusDescr
                FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }

        public bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();
            return countStudents == 0 ? true : false;
        }

        public void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach (Student student in StudentData.students)
            {
                context.Students.Add(student);
            }
            context.SaveChanges();

        }

        private void ClearAllControls()
        {
            foreach (var item in PersonalDataGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }

                if (item is TextBlock)
                {
                    ((TextBlock)item).Text = "";
                }
            }

            foreach (var item in StudentInfoGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }

                if (item is TextBlock)
                {
                    ((TextBlock)item).Text = "";
                }
            }

        }

        private void FillControls(Student fillStudent)
        {
            txtFirstName.Text = fillStudent.firstName;
            txtSecondName.Text = fillStudent.surName;
            txtLastName.Text = fillStudent.lastName;
            txtFaculty.Text = fillStudent.faculty;
            txtSpecialty.Text = fillStudent.specialty;
            txtEQD.Text = fillStudent.EQD;
            txtStatus.Text = fillStudent.status;
            txtPotok.Text = fillStudent.potok.ToString();
            txtCourse.Text = fillStudent.course.ToString();
            txtGroup.Text = fillStudent.group.ToString();
            txtFacultyNumber.Text = fillStudent.facultyNumber;
        }

        private void DeactivateControls()
        {
            foreach (var item in PersonalDataGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = false;
                }

                if (item is TextBlock)
                {
                    ((TextBlock)item).IsEnabled = false;
                }

            }

            foreach (var item in StudentInfoGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = false;
                }

                if (item is TextBlock)
                {
                    ((TextBlock)item).IsEnabled = false;
                }

            }

        }

        private void ActivateControls()
        {
            foreach (var item in PersonalDataGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = true;
                }

                if (item is TextBlock)
                {
                    ((TextBlock)item).IsEnabled = true;
                }

            }

            foreach (var item in StudentInfoGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = true;
                }

                if (item is TextBlock)
                {
                    ((TextBlock)item).IsEnabled = true;
                }

            }

        }

        
            

        private void Login()
        {
            Student firstStudent = StudentData.students.OrderBy(s => s.firstName).ThenBy(s => s.surName).ThenBy(s => s.lastName).First();
            ActivateControls();
            FillControls(firstStudent);
        }

        private void Logout()
        {
            ClearAllControls();
            DeactivateControls();
        }
        private void btnFill_Click(object sender, RoutedEventArgs e)
        {
            FillControls(StudentData.students[0]);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearAllControls();
        }

        private void btnDeactivate_Click(object sender, RoutedEventArgs e)
        {
            DeactivateControls();
        }

        private void btnActivate_Click(object sender, RoutedEventArgs e)
        {
            ActivateControls();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Logout();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            CmBoxStatus.ItemsSource = StudStatusChoices;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool result = TestStudentsIfEmpty();
            MessageBox.Show(result.ToString());
        }
    }
}

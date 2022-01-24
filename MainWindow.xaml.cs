using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace StudentManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Person> personList = new List<Person>();
        List<string> personNames = new List<string>();

        List<Courses> courseList = new List<Courses>();
        List<List<Courses>> studCourseList = new List<List<Courses>>();
        List<string> courseNames = new List<string>();

        private delegate void EmptyDelegate();

        public MainWindow()
        {
            InitializeComponent();
            Gender();
            Level();
        }

        void Gender()
        {
            string[] genderArray = { "Male", "Female" };
            genderList.ItemsSource = genderArray;
        }

        void Level()
        {
            string[] levelArray = { "Undergraduate", "Graduate" };
            level.ItemsSource = levelArray;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Person stud;

            if (level.SelectedIndex == 0)
            {
                stud = new UndergraduateStudent(
                    fName.Text,
                    lName.Text,
                    Convert.ToInt32(studId.Text),
                    genderList.SelectedIndex == 0 ? "Male" : "Female",
                    Convert.ToByte(age.Text),
                    "Undergraduate"
                    );
            }
            else
            {
                stud = new GraduateStudent(
                    fName.Text,
                    lName.Text,
                    Convert.ToInt32(studId.Text),
                    genderList.SelectedIndex == 0 ? "Male" : "Female",
                    Convert.ToByte(age.Text),
                    "Graduate"
                    );
            }

            personNames.Add(stud.FName + " " + stud.LName);
            personList.Add(stud);
            List<Courses> courses = new List<Courses>();
            studCourseList.Add(courses);
            UpdateStudentList(personNames);
        }

        void UpdateStudentList(List<string> people)
        {
            studList.ItemsSource = people;
            studList.Items.Refresh();
        }

        private void studList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selected = studList.SelectedIndex;
            if (selected > -1)
            {
                fName.Text = personList.ElementAt(studList.SelectedIndex).FName;
                lName.Text = personList.ElementAt(studList.SelectedIndex).LName;
                studId.Text = personList.ElementAt(studList.SelectedIndex).StudID.ToString();
                age.Text = personList.ElementAt(studList.SelectedIndex).Age.ToString();
                level.SelectedIndex = personList.ElementAt(studList.SelectedIndex).Level == "Undergraduate" ? 0 : 1;
                genderList.SelectedIndex = personList.ElementAt(studList.SelectedIndex).Gender == "Male" ? 0 : 1;

                UpdateCourseList();

            }
        }

        private void courseList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (coursesList.SelectedIndex > -1)
            {
                Courses selectedCourse = studCourseList[studList.SelectedIndex].ElementAt(coursesList.SelectedIndex);

                courseName.Text = selectedCourse.CourseName;
                courseNo.Text = selectedCourse.CourseNo;
                creditHrs.Text = selectedCourse.CreditHrs.ToString();
                courseGPA.Text = selectedCourse.CourseGPA.ToString();

                totalGPA.Text = (selectedCourse.CourseGPA * selectedCourse.CreditHrs / 50).ToString();

            }
        }

        private void addCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (studList.SelectedIndex != -1)
            {

                List<Courses> courses = studCourseList[studList.SelectedIndex];
                Courses course = new Courses(
                    courseNo.Text,
                    courseName.Text,
                    Convert.ToDouble(courseGPA.Text),
                    Convert.ToDouble(creditHrs.Text),
                    Convert.ToDouble(totalGPA.Text)
                    );
                courseNames.Add(course.CourseName);
                courses.Add(course);
                studCourseList[studList.SelectedIndex] = courses;


                UpdateCourseList();
            }

        }

        List<string> CoursesToString()
        {
            List<string> courseNames = new List<string>();

            foreach (Courses course in studCourseList[studList.SelectedIndex])
            {
                courseNames.Add(course.CourseName);
            }

            return courseNames;
        }

        void UpdateCourseList()
        {
            coursesList.ItemsSource = CoursesToString();
            coursesList.Items.Refresh();
        }
    }
}

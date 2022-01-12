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

namespace StudentManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Person> personList = new List<Person>();
        List<string> personNames = new List<string>();

        private delegate void EmptyDelegate();

        public MainWindow()
        {
            InitializeComponent();
            Gender();
            Level();
            //Persons = new List<Person>();
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

            personNames.Add(stud.FName+" "+stud.LName);
            personList.Add(stud);
            UpdateList(personNames);
        }

        void UpdateList(List<string> people)
        {
            studList.ItemsSource = people;
            studList.Items.Refresh();
        }

        private void studList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selected = studList.SelectedIndex;
            if (selected > -1)
            {
                //courseNo.Text = personList.ElementAt(selected).Level;
                fName.Text = personList.ElementAt(studList.SelectedIndex).FName;
                lName.Text = personList.ElementAt(studList.SelectedIndex).LName;
                studId.Text = personList.ElementAt(studList.SelectedIndex).StudID.ToString();
                age.Text = personList.ElementAt(studList.SelectedIndex).Age.ToString();
                level.SelectedIndex = personList.ElementAt(studList.SelectedIndex).Level == "Undergraduate" ? 0 : 1;
                genderList.SelectedIndex = personList.ElementAt(studList.SelectedIndex).Gender == "Male" ? 0 : 1;
            }
        }


    }
}

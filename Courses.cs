namespace StudentManagement
{
    internal class Courses
    {
        public Courses(string courseNo, string courseName, double courseGPA, double creditHrs, double totalGPA)
        {
            CourseName = courseName;
            CourseGPA = courseGPA;
            CreditHrs = creditHrs;
            TotalGPA = totalGPA;
            CourseNo = courseNo;
        }

        public Courses() { }

        public string CourseNo { get; set; }
        public string CourseName { get; set; }
        public double CreditHrs { get; set; }
        public double TotalGPA { get; set; }
        public double CourseGPA { get; set; }
    }
}

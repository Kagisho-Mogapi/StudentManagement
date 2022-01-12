using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    internal class Person
    {

        public Person(string fName, string lName, int studID, string gender, byte age, string level)
        {
            FName = fName;
            LName = lName;
            StudID = studID;
            Gender = gender;
            Age = age;
            Level = level;
        }
        internal string FName { get; set; }
        internal string LName { get; set; }
        internal int StudID { get; set; }
        internal string Gender { get; set; }
        internal byte Age { get; set; }
        internal string Level { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    internal class Person
    {
        string fName;
        string lName;
        string studID;
        string gender;
        byte age;
        string level;

        public Person(string fName, string lName, string studID, string gender, byte age, string level)
        {
            this.fName = fName;
            this.lName = lName;
            this.studID = studID;
            this.gender = gender;
            this.age = age;
            this.level = level;
        }
    }
}

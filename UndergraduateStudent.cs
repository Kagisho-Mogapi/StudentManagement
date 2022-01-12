using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    internal class UndergraduateStudent : Person
    {
        public UndergraduateStudent(string fName, string lName, int studID, string gender, byte age, string level) : base(fName, lName, studID, gender, age, level)
        {

        }
    }
}

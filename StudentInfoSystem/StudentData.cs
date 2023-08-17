using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    class StudentData
    {
        public static List<Student> students
        {
            get {
                ResetStudents();
                return testStudents;   
            }
            private set { } 
        }


        static private List<Student> testStudents;

        static private void ResetStudents()
        {
            if (testStudents == null)
            {
                testStudents= new List<Student>();

                testStudents.Add(new Student());
                testStudents[0].firstName = "Dimitar";
                testStudents[0].surName = "Ivanov";
                testStudents[0].lastName = "Petrov";
                testStudents[0].faculty = "FKST";
                testStudents[0].specialty = "CSE";
                testStudents[0].EQD = "Bachelor";
                testStudents[0].status = "Zaveril";
                testStudents[0].facultyNumber = "121220300";
                testStudents[0].course = 3;
                testStudents[0].potok = 10;
                testStudents[0].group = 88;

                testStudents.Add(new Student());
                testStudents[1].firstName = "Aleksandar";
                testStudents[1].surName = "Minkov";
                testStudents[1].lastName = "Bogdanov";
                testStudents[1].faculty = "FKST";
                testStudents[1].specialty = "CSE";
                testStudents[1].EQD = "Bachelor";
                testStudents[1].status = "Zaveril";
                testStudents[1].facultyNumber = "121220350";
                testStudents[1].course = 3;
                testStudents[1].potok = 10;
                testStudents[1].group =75;

                testStudents.Add(new Student());
                testStudents[2].firstName = "Veronika";
                testStudents[2].surName = "Krasimirova";
                testStudents[2].lastName = "Naydenova";
                testStudents[2].faculty = "FKST";
                testStudents[2].specialty = "CSE";
                testStudents[2].EQD = "Bachelor";
                testStudents[2].status = "Zaveril";
                testStudents[2].facultyNumber = "121220289";
                testStudents[2].course = 4;
                testStudents[2].potok = 7;
                testStudents[2].group = 22;

                
            }
        }

    }
}

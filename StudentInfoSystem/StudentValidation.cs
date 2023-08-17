using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    class StudentValidation
    {
        public static Student GetStudentDataByUser(User user)
        {
            if (user.FacNum == null || (from s in StudentData.students where user.FacNum == s.facultyNumber select s).First() == null)
            {
                Console.WriteLine("Wrong data");
                return null;
            }
            return (Student)(from s in StudentData.students where user.FacNum == s.facultyNumber select s);
        }
    }
}

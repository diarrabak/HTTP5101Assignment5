using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment5_B_Diarra.Models
{
    //This extended class allows getting teacher information and its teachings
    public class Teacher
    {
        public int teacherId;
        public string firstName;
        public string surName;
        public string employeeNumber;
        public DateTime hireDate;
        public decimal salary;

        //Modules taught by the teacher
        public List<ClassModule> modulesTaught;
    }
}
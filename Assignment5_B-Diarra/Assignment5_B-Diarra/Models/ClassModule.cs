using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment5_B_Diarra.Models
{
	//To avoid confusion with term class, I added to module to be more explicit
    public class ClassModule
    {
        public int classId;
        public int teacherId;
        public string classCode;
        public string className;
        public DateTime startDate;
        public DateTime finishDate;

        //Teacher information
        public Teacher professor;
    }
}
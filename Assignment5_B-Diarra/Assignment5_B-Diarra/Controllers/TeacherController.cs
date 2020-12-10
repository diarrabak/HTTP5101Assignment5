using Assignment5_B_Diarra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment5_B_Diarra.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher/Index
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// This View is used to enter the information to be searched in the database
        /// </summary>
        /// <returns></returns>
        // GET: Teacher/SearchIndex
        public ActionResult SearchTeacher()
        {
            return View();
        }
        /// <summary>
        /// This method puts in a list all teachers returned by the Query
        /// <example>GET: Teacher/List/Sam </example>
        /// </summary>
        /// <returns>it returns the list of teachers with name, employee number and hire date</returns>
        // 
        public ActionResult List(string keyword=null)
        {
            TeacherDataController list = new TeacherDataController();
            List<Teacher> teacherList = list.ListTeachers(keyword).ToList();
            return View(teacherList);
        }


        /// <summary>
        /// This method displays a teacher selected by the primary key techearid. It also shows the modules taught by the teacher.
        /// </summary>
        /// <param name="id"></param>
        /// <example>Teacher/Show/1 </example>
		/// <example>Teacher/Show/5 </example>
        /// <returns>Teacher name, employee number, hire date and modules taught to view</returns>
        // 
        
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher selectedTeacher = controller.displayTeacher(id);

            return View(selectedTeacher);
        }


        /// <summary>
        /// This method inserts a new teacher in the database
        /// </summary>
        /// <param name="fname">Teacher's first name</param>
        /// <param name="lname">Teacher's last name</param>
        /// <param name="employeenumber">Teacher's employee number </param>
        /// <param name="hireDate">Teacher's hire date</param>
        /// <param name="salary">Teacher's salary</param>
        /// <returns>Go back to the list of teachers</returns>

        //POST : /Teacher/Add
        [HttpPost]
        public ActionResult Add(string fname, string lname,string employeenumber, DateTime hireDate, decimal salary)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.AddNewTeacher(fname, lname, employeenumber, hireDate, salary);
            return RedirectToAction("List");
        }


        // GET: Teacher/NewTeacher
        public ActionResult NewTeacher()
        {
            return View();
        }

        /// <summary>
        /// This method deletes a teacher from the table
        /// </summary>
        /// <param name="id">Teacher primary key number from the table</param>
        /// <returns>Go back to the list of teachers</returns>

        //POST : /Teacher/removeTeacher
        [HttpPost]
        public ActionResult removeTeacher(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.deleteTeacher(id);
            return RedirectToAction("List");
        }

        /// <summary>
        /// Ajax function allowing to add a new teacher to the table
        /// </summary>
        /// <returns></returns>
        //GET : /Author/Ajax_NewTeacher
        public ActionResult Ajax_NewTeacher()
        {
            return View();

        }

        /// <summary>
        /// This method permits to display the properties of teacher using the primary key in the table
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <example>Teacher/Update/2</example>
        /// <example>Teacher/Update/6</example>
        /// <returns>It returns the teacher whose key is parameter</returns>
        //GET: Teacher/Update/{id}
        public ActionResult Update(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.displayTeacher(id);

            return View(SelectedTeacher);
        }

        /// <summary>
        /// This method permits to add the property of the selected teacher
        /// </summary>
        /// <param name="id">teacherid, primary key from the table</param>
        /// <param name="fname">Teacher name</param>
        /// <param name="lname">Teacher surname</param>
        /// <param name="employeenumber">Teacher employee number</param>
        /// <param name="hireDate">Teacher hire date</param>
        /// <param name="salary">Teacher salary</param>
        /// <returns>Go back to the teacher who has be updated</returns>
        //POST : /Teacher/Update
        [HttpPost]
        public ActionResult Update(int id, string fname, string lname, string employeenumber, DateTime hireDate, decimal salary)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.UpdateTeacher(id, fname, lname, employeenumber, hireDate, salary);
            return RedirectToAction("Show/" + id); //Go to the updated teacher
        }

    }
}
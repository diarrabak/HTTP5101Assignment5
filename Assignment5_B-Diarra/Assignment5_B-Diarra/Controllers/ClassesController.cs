using Assignment5_B_Diarra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment5_B_Diarra.Controllers
{
    public class ClassesController : Controller
    {
        // GET: Classes
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This method put in a list all classes and teacher names returned by the Query
        /// <example>GET: Classes/Classlist </example>
        /// </summary>
        /// <returns>it returns the list of classes with name,code, start and end date and the teacher information</returns>
        // 
        public ActionResult classList()
        {
            ClassesDataController list = new ClassesDataController();
            List<ClassModule> classList = list.ListClasses().ToList();
            return View(classList);
        }
        /// <summary>
        /// This method permits to display a module and its properties including the teacher
        /// </summary>
        /// <param name="id">Primary key identifying the class in the table</param>
        /// <example>Classes/ShowClass/1 </example>
        /// <example>Classes/ShowClass/5 </example>
        /// <returns>The methods return to the view the class which id is chosen </returns>
        /// 
        public ActionResult ShowClass(int id)
        {
            ClassesDataController controller = new ClassesDataController();
            ClassModule selectedModule = controller.displayClasse(id);

            return View(selectedModule);
        }

        /// <summary>
        /// This method permits to show the module in input element to enable editing it
        /// </summary>
        /// <param name="id">Primary key identifying the class in the table</param>
        /// <example>Classes/UpdateClass/2</example>
        /// <example>Classes/UpdateClass/7</example>
        /// <returns>The methods return to the view the class which id is chosen</returns>
        public ActionResult UpdateClass(int id)
        {
            ClassesDataController controller = new ClassesDataController();
            ClassModule SelectedClass = controller.displayClasse(id);

            return View(SelectedClass);
        }

        /// <summary>
        /// This method permits to change the teacher of a module
        /// </summary>
        /// <param name="id">Primary key identifying the class in the table</param>
        /// <param name="teacherId">Id of the teacher teaching it</param>
        /// <returns>Go back to the module after changing teacher</returns>

        //POST : /Classes/UpdateClass
        [HttpPost]
        public ActionResult UpdateClass(int id, long teacherId)
        {
            ClassesDataController controller = new ClassesDataController();
            controller.UpdateClasse(id, teacherId);
            return RedirectToAction("ShowClass/" + id);
        }
    }
}
﻿using Assignment5_B_Diarra.Models;
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        public ActionResult ShowClass(int id)
        {
            ClassesDataController controller = new ClassesDataController();
            ClassModule selectedModule = controller.displayClasse(id);

            return View(selectedModule);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UpdateClass(int id)
        {
            ClassesDataController controller = new ClassesDataController();
            ClassModule SelectedClass = controller.displayClasse(id);

            return View(SelectedClass);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="teacherId"></param>
        /// <returns></returns>

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
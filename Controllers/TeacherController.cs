using project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project3.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }
        //GET : /Teacher/ListTeachers
        public ActionResult ListTeachers()
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers();
            return View(Teachers);
        }

        //GET : /Teacher/ShowTeachers/{id}
        public ActionResult ShowTeachers(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);
            return View(NewTeacher);
        }
        //GET : /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
           TeacherDataController controller = new TeacherDataController();
           Teacher Newteacher = controller.FindTeacher(id);


            return View(Newteacher);
        }


        //POST : /Teacher/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.Deleteteacher(id);
            return RedirectToAction("List");
        }

        //GET : /Teacher/New
        public ActionResult New()
        {
            return View();
        }
        //POST : /Teacher/Create
        [HttpPost]
        public ActionResult Create(string teacherlname, string teacherfname, string employeenumber, int salary)
        {
            //Identify that this method is running
            //Identify the inputs provided from the form

           
            Teacher Newteacher = new Teacher();
            Newteacher.TeacherFname = teacherfname;
            Newteacher.TeacherLname = teacherlname;
            Newteacher.Salary = salary;
            Newteacher.EmployeeNumber = employeenumber;

            TeacherDataController controller = new TeacherDataController();
            controller.Addteacher(Newteacher);

            return RedirectToAction("ListTeachers");
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="id">Id of the Teacher</param>
        /// <returns>A dynamic "Update Teacher" webpage which provides the current information of the Teacher and asks the user for new information as part of a form.</returns>
        /// <example>GET : /Teacher/Update/5</example>
        public ActionResult Update(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.FindTeacher(id);

            return View(SelectedTeacher);
        }

        public ActionResult Ajax_Update(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.FindTeacher(id);

            return View(SelectedTeacher);
        }


    }
}
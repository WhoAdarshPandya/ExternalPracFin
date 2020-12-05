using ExternalPracFin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExternalPracFin.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var students = SqlPoco.getAllStudents();
            return View(students);
        }

        public ActionResult getTheInsertPage()
        {
            return View("Insert");
        }

        public ActionResult getTheUpdatePage()
        {
            return View("Update");
        }

        public ActionResult getTheDeletePage()
        {
            return View("Delete");
        }

        public ActionResult InsertTheStudent(StudentModel student)
        {
            if(!ModelState.IsValid)
            {
                return View("Insert");
            }
            else
            {
                SqlPoco.insertStudent(student.FirstName,student.Course,student.Year,Convert.ToChar(student.Gender));
                return RedirectToAction("Index");
            }
        }

        public ActionResult UpdateTheStudent(StudentModel student)
        {
            if(!ModelState.IsValid)
            {
                return View("Update");
            }
            else
            {
                SqlPoco.UpdateStudent(student.Id, student.FirstName, student.Course, student.Year, Convert.ToChar(student.Gender)); 
                return RedirectToAction("Index");
            }
        }

        public ActionResult DeleteTheStudent(DeleteModel d)
        {
            if (!ModelState.IsValid)
            {
                return View("Delete");
            }
            else
            {
                SqlPoco.DeleteStudent(d.Id);
                return RedirectToAction("Index");
            }
        }
    }
}
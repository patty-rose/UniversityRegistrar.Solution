using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityRegistrar.Models;
using System.Collections.Generic;
using System.Linq;

namespace UniversityRegistrar.Controllers
{
  public class StudentsController : Controller
  {
    private readonly UniversityRegistrarContext _db;

    public StudentsController(UniversityRegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Student> model = _db.Students.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.Courses = new List<Course>(_db.Courses);
      ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "CourseName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Student Student, int CourseId)
    {
      _db.Students.Add(Student);
      _db.SaveChanges();
      if (CourseId != 0)
      {
        _db.CourseStudent.Add(new CourseStudent() { CourseId = CourseId, StudentId = Student.StudentId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisStudent = _db.Students.Include(student => student.JoinEntities).ThenInclude(join => join.Course).FirstOrDefault(Student => Student.StudentId == id);
      return View(thisStudent);
    }

    public ActionResult Edit(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
      ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "CourseName");
      return View(thisStudent);
    }

    [HttpPost]
    public ActionResult Edit(Student student, int CourseId)
    {
      if (CourseId != 0)
      {
        _db.CourseStudent.Add(new CourseStudent() { CourseId = CourseId, StudentId = student.StudentId });
      }
      _db.Entry(student).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult DeclareMajor(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(Student => Student.StudentId == id);
      ViewBag.DepartmentId = new SelectList(_db.Departments, "DepartmentId", "DepartmentName");
      return View(thisStudent);
    }

    [HttpPost]
    public ActionResult DeclareMajor(Student student, int DepartmentId)
    {
      if (DepartmentId != 0)
      {
        _db.DepartmentStudent.Add(new DepartmentStudent() { DepartmentId = DepartmentId, StudentId = student.StudentId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    // public ActionResult AddCourse(int id)
    // {
    //   var thisStudent = _db.Students.FirstOrDefault(Student => Student.StudentId == id);
    //   ViewBag.CourseId = new SelectList(_db.Categories, "CourseId", "Name");
    //   return View(thisStudent);
    // }

    // [HttpPost]
    // public ActionResult AddCourse(Student Student, int CourseId)
    // {
    //   if (CourseId != 0)
    //   {
    //     _db.CourseStudent.Add(new CourseStudent() { CourseId = CourseId, StudentId = Student.StudentId });
    //     _db.SaveChanges();
    //   }
    //   return RedirectToAction("Index");
    // }

    public ActionResult Delete(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
      return View(thisStudent);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
      _db.Students.Remove(thisStudent);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    // [HttpPost]
    // public ActionResult DeleteCourse(int joinId)
    // {
    //   var joinEntry = _db.CourseStudent.FirstOrDefault(entry => entry.CourseStudentId == joinId);
    //   _db.CourseStudent.Remove(joinEntry);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
  }
}
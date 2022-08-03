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
      return View(_db.Students.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Student student)
    {
    
      _db.Entry(student).State = EntityState.Modified;
      _db.SaveChanges();
      return View();
    }

    // [HttpPost]
    // public ActionResult Create(Student Student, int CategoryId)
    // {
    //   _db.Students.Add(Student);
    //   _db.SaveChanges();
    //   if (CategoryId != 0)
    //   {
    //     _db.CategoryStudent.Add(new CategoryStudent() { CategoryId = CategoryId, StudentId = Student.StudentId });
    //     _db.SaveChanges();
    //   }
    //   return RedirectToAction("Index");
    // }

    // public ActionResult Details(int id)
    // {
    //   var thisStudent = _db.Students.Include(Student => Student.JoinEntities).ThenInclude(join => join.Category).FirstOrDefault(Student => Student.StudentId == id);
    //   return View(thisStudent);
    // }
    // public ActionResult Edit(int id)
    // {
    //   var thisStudent = _db.Students.FirstOrDefault(Student => Student.StudentId == id);
    //   ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
    //   return View(thisStudent);
    // }

    // [HttpPost]
    // public ActionResult Edit(Student Student, int CategoryId)
    // {
    //   if (CategoryId != 0)
    //   {
    //     _db.CategoryStudent.Add(new CategoryStudent() { CategoryId = CategoryId, StudentId = Student.StudentId });
    //   }
    //   _db.Entry(Student).State = EntityState.Modified;
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    // public ActionResult AddCategory(int id)
    // {
    //   var thisStudent = _db.Students.FirstOrDefault(Student => Student.StudentId == id);
    //   ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
    //   return View(thisStudent);
    // }

    // [HttpPost]
    // public ActionResult AddCategory(Student Student, int CategoryId)
    // {
    //   if (CategoryId != 0)
    //   {
    //     _db.CategoryStudent.Add(new CategoryStudent() { CategoryId = CategoryId, StudentId = Student.StudentId });
    //     _db.SaveChanges();
    //   }
    //   return RedirectToAction("Index");
    // }

    // public ActionResult Delete(int id)
    // {
    //   var thisStudent = _db.Students.FirstOrDefault(Student => Student.StudentId == id);
    //   return View(thisStudent);
    // }

    // [HttpPost, ActionName("Delete")]
    // public ActionResult DeleteConfirmed(int id)
    // {
    //   var thisStudent = _db.Students.FirstOrDefault(Student => Student.StudentId == id);
    //   _db.Students.Remove(thisStudent);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    // [HttpPost]
    // public ActionResult DeleteCategory(int joinId)
    // {
    //   var joinEntry = _db.CategoryStudent.FirstOrDefault(entry => entry.CategoryStudentId == joinId);
    //   _db.CategoryStudent.Remove(joinEntry);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
  }
}
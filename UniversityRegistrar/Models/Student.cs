using System.Collections.Generic;
using System;

namespace UniversityRegistrar.Models
{
  public class Student
  {

    public Student()
      {
          this.JoinEntities = new HashSet<CourseStudent>();
          this.JoinDeptStu = new HashSet<DepartmentStudent>();
      }
      
    // auto implemented properties
    public string Name { get; set; }
    public int StudentId { get; set; }
    public string EnrollmentDate { get; set; }
    public virtual ICollection<CourseStudent> JoinEntities { get; }
    public virtual ICollection<DepartmentStudent> JoinDeptStu { get; }
  }
}
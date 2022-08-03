using System.Collections.Generic;
using System;

namespace UniversityRegistrar.Models
{
  public class Student
  {

    public Student()
      {
          this.JoinEntities = new HashSet<CourseStudent>();
      }
      
    // auto implemented properties
    public string Name { get; set; }
    public int StudentId { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public virtual ICollection<CourseStudent> JoinEntities { get; }
  }
}
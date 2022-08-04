using System.Collections.Generic;

namespace UniversityRegistrar.Models
{
    public class Course
    {
        public Course()
        {
            this.JoinCourseDept = new HashSet<CourseDepartment>();

            this.JoinEntities = new HashSet<CourseStudent>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseNumber { get; set; }
        public virtual ICollection<CourseDepartment> JoinCourseDept { get; set; }
        public virtual ICollection<CourseStudent> JoinEntities { get; set; }
    }
}
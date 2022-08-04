using System.Collections.Generic;

namespace UniversityRegistrar.Models
{
    public class Department
    {
        public Department()
        {
            this.JoinCourseDept = new HashSet<CourseDepartment>();
            this.JoinDeptStu = new HashSet<DepartmentStudent>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public virtual ICollection<CourseDepartment> JoinCourseDept { get; set; }
        public virtual ICollection<DepartmentStudent> JoinDeptStu { get; set; }
    }
}
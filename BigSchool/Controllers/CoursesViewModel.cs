using System.Collections.Generic;
using System.Linq;
using BigSchool.Models;

namespace BigSchool.Controllers
{
    internal class CoursesViewModel
    {
        internal IQueryable<Course> upcommingCourses;

        public List<Category> Categories { get; set; }
        public bool ShowAction { get; internal set; }
    }
}
using BigSchool.Models;
using BigSchool.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigSchool.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;
    
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }


        public ActionResult Index()
        {

            var userId = User.Identity.GetUserId();

            var upcomingCourses = _dbContext.Courses
                .Include(c => c.Lecturer)
                .Include(c => c.Category)
                .Where(c => c.Datetime > DateTime.Now);


            var attend = _dbContext.Attendances
                   .Include(a => a.Attendee)
                   .Include(a => a.Course)
                   .Where(a => a.AttendeeId == userId)
                   .ToList();

            var viewModel = new CoursesViewModel
            {
                UpcomingCourses = upcomingCourses,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
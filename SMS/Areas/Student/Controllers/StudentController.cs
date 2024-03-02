using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SMS.Controllers;
using SMS.Models;
using System;

namespace SMS.Areas.Student.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly UserManager<AppUser> _userManager;

        public StudentController(ILogger<StudentController> logger, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var user = _userManager.GetUserName(HttpContext.User);
            _logger.LogInformation("Student View opened by user:"+ _userManager.GetUserName(HttpContext.User));
            return View();
        }
    }
}

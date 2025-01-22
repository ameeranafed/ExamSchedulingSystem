
using ExamSchedulingSystem.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using ExamSchedulingSystem.Models;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace ExamSchedulingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult FacultyLogin(string role)
        {
            TempData["FacultyRole"] = role;
            ViewBag.Role = role;  
            return View();
          
        }

        [HttpPost]
        public IActionResult FacultyLogin(string id, string password, string role)
        {
           


            var user = _context.Users.FirstOrDefault(u => u.UserId == id && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("UserId", user.UserId);
                HttpContext.Session.SetString("CoordinatorId", user.UserId);
                HttpContext.Session.SetString("UserName", user.Name);

               
                if (user.Role.ToString() == role)
                {
                    switch (user.Role)
                    {
                       
                        case UserRole.Faculty:
                            return RedirectToAction("FacultyDashboard", new { userId = user.UserId });
                        case UserRole.Admin:
                            return RedirectToAction("AdminDashboard");
                        default:
                            return RedirectToAction("FacultyLogin");
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Incorrect role for the provided ID.";
                    ViewBag.Role = role;
                    return View();
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid ID or Password.";
                ViewBag.Role = role;
                return View();
            }

        }
        [HttpGet]
      public IActionResult Login(string role)

    {
            TempData["RoleS"] = role;
            ViewBag.Role = role;  
            return View();
            
    }

        
        [HttpPost]
        public IActionResult Login(string id, string password, string role)
        {
           
           
            var user = _context.Users.FirstOrDefault(u => u.UserId == id && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("UserId", user.UserId);
                HttpContext.Session.SetString("UserName", user.Name);
                TempData["RoleS"] = user.Role.ToString();
                ViewBag.Role = user.Role.ToString();

                if (user.Role.ToString() == role)
                {

                    return RedirectToAction("StudentDashboard");
}
                else
                {
                    ViewBag.ErrorMessage = "Incorrect role for the provided ID.";
                    ViewBag.Role = role;
                    return View();
                }


            }
            else
            {
                ViewBag.ErrorMessage = "Invalid ID or Password.";
                ViewBag.Role = role;
                return View();
            } 

        }



        [HttpGet]
        public IActionResult StudentDashboard()
        {
            TempData["RoleS"] = "Student";
            TempData.Keep("RoleS");
            return View();
        }

        [HttpGet]
        public IActionResult AdminDashboard()
        {
            TempData["RoleS"] = "Admin";
            TempData.Keep("RoleS");
            return View();
        }

        [HttpGet]
        public IActionResult Guest()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult VerifyIdentity(string role)
        {
            Console.WriteLine($"Redirected to VerifyIdentity. Role: {role}");
            TempData["UserRole"] = role;
            return View();
          
        }


        [HttpPost]
        public IActionResult VerifyIdentity(ForgotPasswordViewModel model)
        {
            
            var role = TempData["UserRole"] as string;

            
            if (string.IsNullOrEmpty(role))
            {
                ModelState.AddModelError("", "Role information is missing.");
                return View(model);
            }

            
            if (role == "Student" && !Regex.IsMatch(model.Email ?? "", @"^[0-9]+@std\.hu\.edu\.jo$"))
            {
                ModelState.AddModelError("Email", "Invalid Email Format for Student.");
                return View(model);
            }
            else if ((role == "Faculty" || role == "Admin") && !Regex.IsMatch(model.Email ?? "", @"^[a-z]+@hu\.edu\.jo$"))
            {
                ModelState.AddModelError("Email", "Invalid Email Format for Faculty or Admin.");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);
                if (user != null)
                {
                    
                    
                    

                    TempData["UserEmail"] = model.Email;
                    TempData["UserRole"] = role;

                   
                    return RedirectToAction("ResetCodeSent");
                }
                else
                {
                    ModelState.AddModelError("Email", "Email not found.");
                    return View(model);
                }
            }

           
            return View(model);
        }




        public string GenerateResetCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }
        [HttpGet]
        public IActionResult ResetCodeSent()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult ResetCodeSent(ForgotPasswordViewModel model)
        {

            TempData["reset"] = "123456";
            

            string? code = TempData.Peek("reset") as string;

            var email = TempData["UserEmail"] as string;
            var role = TempData["UserRole"] as string;
            if (model.Code.ToString() == code)
            {
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(role))
                {
                    return RedirectToAction("ResetPassword", new { email = email, role = role });
                }
                else
                {
                    ModelState.AddModelError("", "Email or role is missing.");
                    return View();
                }
            }

            ModelState.AddModelError("Code", "Invalid reset code. Please try again.");
            return View(model);
        }


        [HttpGet]
        public IActionResult ResetPassword(string email, string role)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(role))
            {
                ModelState.AddModelError("", "Email or role is missing.");
                return RedirectToAction("VerifyIdentity");
            }
            TempData["Email"] = email;
            TempData["Role"] = role;
            TempData.Keep("Email");
            TempData.Keep("Role");

            string? FacultyRole = TempData["FacultyRole"] as string;
            string? RoleS = TempData["RoleS"] as string;
            Console.WriteLine($"TempData Email: {TempData.Peek("Email")}, Role: {TempData.Peek("Role")}");

            var model = new ResetPasswordViewModel
            {
                Email = email,
                Role = role
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel model)
        {
            
            model.Email = TempData.Peek("Email") as string; 
            model.Role = TempData.Peek("Role") as string;  

            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Role))
            {
                ModelState.AddModelError("", "Email or role is missing.");
                return RedirectToAction("VerifyIdentity");
            }

            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);
                if (user != null)
                {
                  
                    user.Password = model.Password;
                    _context.SaveChanges();

                    
                    switch (model.Role)
                    {
                        case "Student":
                            return RedirectToAction("Login", new { role = "Student" });
                        case "Faculty":
                            return RedirectToAction("FacultyLogin", new { role = "Faculty" });
                        case "Admin":
                            return RedirectToAction("FacultyLogin", new { role = "Admin" });
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User not found.");
                }
            }

           
            return View(model);
        }

        [HttpGet]
        public IActionResult SignUp(string role)
        {
            ViewBag.Role = role;
            return View();
        }

        
        [HttpGet]
        public JsonResult CheckUniqueness(string type, string value)
        {
            bool exists = false;

            if (type == "UserId")
            {
                exists = _context.Users.Any(u => u.UserId == value);
            }
            else if (type == "Email")
            {
                exists = _context.Users.Any(u => u.Email == value);
            }

            return Json(new { exists });
        }

        [HttpPost]
        public IActionResult SignUp(User user, string confirmPassword, string role)
        {
           
            if (ModelState.IsValid)
            {
                var emailRegex = new System.Text.RegularExpressions.Regex(@"^[0-9]+@std\.hu\.edu\.jo$");
                if (!emailRegex.IsMatch(user.Email))
                {
                    ModelState.AddModelError("Email", "Invalid email format. Must be like 2143217@std.hu.edu.jo.");
                    return View(user);
                }

                
                if (user.Password != confirmPassword)
                {
                   
                    ModelState.AddModelError("confirmPassword", "Passwords do not match.");
                    return View(user); 
                }

                
                var existingUser = _context.Users.FirstOrDefault(u => u.UserId == user.UserId || u.Email == user.Email);
                if (existingUser != null)
                {
                    if (existingUser.UserId == user.UserId)
                    {
                        ModelState.AddModelError("UserId", "A user with this ID already exists.");
                    }

                    if (existingUser.Email == user.Email)
                    {
                        ModelState.AddModelError("Email", "A user with this email already exists.");
                    }

                    return View(user);
                }

               
                
                        user.Role = UserRole.Student;

                        var student = new ExamSchedulingSystem.Models.Student
                        {
                            UserId = user.UserId 
                        };
                        _context.Students.Add(student);



               
                _context.Users.Add(user);
                _context.SaveChanges();

                

                
                return RedirectToAction("Login", new { role = role });
            }

           
            return View(user);
        }




       
        [HttpGet]
       public IActionResult FacultyDashboard(string userId)
{
    var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
    if (user == null || user.Role != UserRole.Faculty)
    {
        return RedirectToAction("Login", new { role = "Faculty" });
    }

   
    TempData["UserId"] = user.UserId;
    TempData.Keep("UserId"); 

  
    return View(user);  
}

      
       
       
        [HttpPost]
        public IActionResult FacultyDashboardd(string selectedFacultyRole)
        {
            var userId = TempData["UserId"]?.ToString();
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("FacultyLogin", new { role = "Faculty" });
            }

            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null || user.Role != UserRole.Faculty)
            {
                return RedirectToAction("FacultyLogin", new { role = "Faculty" });
            }

            if (Enum.TryParse(selectedFacultyRole, true, out FacultyRole role))
            {
                user.FacultyRole = role;
                _context.SaveChanges();
            }
            TempData["RoleS"] = user.FacultyRole.ToString();
            TempData.Keep("RoleS");

            
            switch (user.FacultyRole)
            {
                case FacultyRole.Coordinator:
                    return RedirectToAction("CoordinatorDashboard");
                case FacultyRole.Teacher:
                    return RedirectToAction("TeacherDashboard");
                case FacultyRole.Invigilator:
                    return RedirectToAction("InvigilatorDashboard");
               
            }

            return RedirectToAction("FacultyLogin", new { role = "Faculty" });
        }

        [HttpGet]
        public IActionResult CoordinatorDashboard()
        {
            
                var coordinatorId = HttpContext.Session.GetString("CoordinatorId");

               
                var currentDate = DateTime.Now.Date;
                var currentExamPeriod = _context.Calendars
                    .FirstOrDefault(c => c.StartDate <= currentDate && c.EndDate >= currentDate);

                ViewBag.Announcement = currentExamPeriod != null
                    ? $"Exam period for {currentExamPeriod.ExamType} is active. Please reserve your exams before {currentExamPeriod.EndDate:yyyy-MM-dd}."
                    : "Currently, we are not in an active exam period.";

            

            TempData["RoleS"] = "Coordinator";
            TempData.Keep("RoleS");
            return View();
        }

        [HttpGet]
        public IActionResult InvigilatorDashboard()
        {
            TempData["RoleS"] = "Invigilator";
            TempData.Keep("RoleS");
            return View();
        }
        [HttpGet]

        public IActionResult TeacherDashboard()
        {
            TempData["RoleS"] = "Teacher";
            TempData.Keep("RoleS");
            return View();
        }


       
        [HttpGet]
        public IActionResult ViewExamsSchedule()
        {
            var examSchedule = _context.ExamSchedules
                .Select(es => new ExamScheduleViewModel
                {
                    ExamName = es.CourseName,
                    ExamDate = es.ExamDate,
                    StartTime = es.StartTime,
                    EndTime = es.EndTime,
                    Room = es.Place
                })
                .ToList();

            return View(examSchedule);
        }

        [HttpGet]
        public IActionResult ViewExamSchedule()
        {
            var examSchedule = _context.ExamSchedules
                .Select(es => new ExamScheduleViewModel
                {
                    ExamName = es.CourseName,
                    ExamDate = es.ExamDate,
                    StartTime = es.StartTime,
                    EndTime = es.EndTime,
                    Room = es.Place
                })
                .ToList();

            return View(examSchedule);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home"); 
        }
        [HttpGet]
        public IActionResult AboutUs()
        {
             return View();
        }
        [HttpGet]
        public IActionResult Calendar()
        {
            var examPeriods = _context.Calendars.ToList();
            return View(examPeriods);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

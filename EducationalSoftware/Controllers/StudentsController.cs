using EducationalSoftware.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Diagnostics;

namespace EducationalSoftware.Controllers
{
    public class StudentsController : Controller
    {
        private readonly DBContext _context;

        public Student? student;

        public StudentsController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.Any, NoStore = true)]
        public IActionResult StudentsLogin()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Clear();
            return View();
                      
        }

        [HttpPost]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.Any, NoStore = true)]
        public IActionResult StudentsLogin(Student model)
        {
            if (ModelState.IsValid)
            {
                student = _context.Students.FirstOrDefault(student => student.Username.Equals(model.Username)
                 && student.Password.Equals(model.Password));

                if (student != null)
                {
                    HttpContext.Session.SetString("username", student.Username);
                    return RedirectToAction("StudentHome");
                }

                ModelState.AddModelError(string.Empty, "Δέν βρέθηκε χρήστης με αυτά τα στοιχεία");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.Any, NoStore = true)]
        public IActionResult StudentHome()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                int x=5;
                return View();
            }
            else
            {
                return RedirectToAction("StudentsLogin", "Students");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.Any, NoStore = true)]
        public IActionResult DataScientistDirection()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("StudentsLogin", "Students");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.Any, NoStore = true)]
        public IActionResult CybersecuritySpecialistDirection()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("StudentsLogin", "Students");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.Any, NoStore = true)]
        public IActionResult SoftwareEngineerDirection()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("StudentsLogin", "Students");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.Any, NoStore = true)]
        public IActionResult UxDesignerDirection()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("StudentsLogin", "Students");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.Any, NoStore = true)]
        public IActionResult AiSpecialistDirection()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("StudentsLogin", "Students");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.Any, NoStore = true)]
        public IActionResult WebDeveloperDirection()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("StudentsLogin", "Students");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.Any, NoStore = true)]
        public IActionResult DataScientistQuiz()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("StudentsLogin", "Students");
            }
        }

        [HttpPost]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.Any, NoStore = true)]
        public async Task<IActionResult> DataScientistQuiz(int score)
        {

            if (HttpContext.Session.GetString("username") != null)
            {
                StudentDirectionQuiz stDirQuiz = new StudentDirectionQuiz();
                stDirQuiz = _context.StudentDirectionQuizzes.
                       FirstOrDefault(u => u.Username == HttpContext.Session.GetString("username") && u.IdDirection == 1);

                stDirQuiz.Score = score;
                _context.Update(stDirQuiz);
                _context.SaveChanges();
                return RedirectToAction("DataScientistDirection", "Students");
            }
            else
            {
                return RedirectToAction("StudentsLogin", "Students");
            }
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.Any, NoStore = true)]
        public IActionResult CyberSecurityQuiz()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("StudentsLogin", "Students");
            }
        }

        [HttpPost]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.Any, NoStore = true)]
        public async Task<IActionResult> CyberSecurityQuiz(int score)
        {

            if (HttpContext.Session.GetString("username") != null)
            {
                StudentDirectionQuiz stDirQuiz = new StudentDirectionQuiz();
                stDirQuiz = _context.StudentDirectionQuizzes.
                       FirstOrDefault(u => u.Username == HttpContext.Session.GetString("username") && u.IdDirection == 2);

                stDirQuiz.Score = score;
                _context.Update(stDirQuiz);
                _context.SaveChanges();
                return RedirectToAction("CybersecuritySpecialistDirection", "Students");
            }
            else
            {
                return RedirectToAction("StudentsLogin", "Students");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.Any, NoStore = true)]
        public IActionResult InsertGrades()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("StudentsLogin", "Students");
            }
        }
    }
}

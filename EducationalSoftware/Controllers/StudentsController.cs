using EducationalSoftware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
              
                String username = HttpContext.Session.GetString("username");
                StudentDirectionTraffic studentDirTraffic= new StudentDirectionTraffic();

                studentDirTraffic = _context.StudentDirectionTraffics.
                    FirstOrDefault(u => u.IdDirection == 1 && u.Username == username);

                studentDirTraffic.Traffic+=1;
                _context.Update(studentDirTraffic);
                _context.SaveChanges();

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
                String username = HttpContext.Session.GetString("username");
                StudentDirectionTraffic studentDirTraffic = new StudentDirectionTraffic();

                studentDirTraffic = _context.StudentDirectionTraffics.
                    FirstOrDefault(u => u.IdDirection == 2 && u.Username == username);

                studentDirTraffic.Traffic += 1;
                _context.Update(studentDirTraffic);
                _context.SaveChanges();

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
                String username = HttpContext.Session.GetString("username");
                StudentDirectionTraffic studentDirTraffic = new StudentDirectionTraffic();

                studentDirTraffic = _context.StudentDirectionTraffics.
                    FirstOrDefault(u => u.IdDirection == 3 && u.Username == username);

                studentDirTraffic.Traffic += 1;
                _context.Update(studentDirTraffic);
                _context.SaveChanges();

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

                String username = HttpContext.Session.GetString("username");
                StudentDirectionTraffic studentDirTraffic = new StudentDirectionTraffic();

                studentDirTraffic = _context.StudentDirectionTraffics.
                    FirstOrDefault(u => u.IdDirection == 4 && u.Username == username);

                studentDirTraffic.Traffic += 1;
                _context.Update(studentDirTraffic);
                _context.SaveChanges();
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
                String username = HttpContext.Session.GetString("username");
                StudentDirectionTraffic studentDirTraffic = new StudentDirectionTraffic();

                studentDirTraffic = _context.StudentDirectionTraffics.
                    FirstOrDefault(u => u.IdDirection == 5 && u.Username == username);

                studentDirTraffic.Traffic += 1;
                _context.Update(studentDirTraffic);
                _context.SaveChanges();

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
                String username = HttpContext.Session.GetString("username");
                StudentDirectionTraffic studentDirTraffic = new StudentDirectionTraffic();

                studentDirTraffic = _context.StudentDirectionTraffics.
                    FirstOrDefault(u => u.IdDirection == 6 && u.Username == username);

                studentDirTraffic.Traffic += 1;
                _context.Update(studentDirTraffic);
                _context.SaveChanges();

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
                String username = HttpContext.Session.GetString("username");
                StudentDirectionQuiz stDirQuiz = new StudentDirectionQuiz();
                stDirQuiz = _context.StudentDirectionQuizzes.
                       FirstOrDefault(u => u.Username == username && u.IdDirection == 2);

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
        public IActionResult SoftwareEngineerQuiz()
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
        public async Task<IActionResult> SoftwareEngineerQuiz(int score)
        {

            if (HttpContext.Session.GetString("username") != null)
            {
                String username = HttpContext.Session.GetString("username");
                StudentDirectionQuiz stDirQuiz = new StudentDirectionQuiz();
                stDirQuiz = _context.StudentDirectionQuizzes.
                       FirstOrDefault(u => u.Username == username && u.IdDirection == 3);

                stDirQuiz.Score = score;
                _context.Update(stDirQuiz);
                _context.SaveChanges();
                return RedirectToAction("SoftwareEngineerDirection", "Students");
            }
            else
            {
                return RedirectToAction("StudentsLogin", "Students");
            }
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.Any, NoStore = true)]
        public IActionResult UxDesignerQuiz()
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
        public async Task<IActionResult> UxDesignerQuiz(int score)
        {

            if (HttpContext.Session.GetString("username") != null)
            {
                String username = HttpContext.Session.GetString("username");
                StudentDirectionQuiz stDirQuiz = new StudentDirectionQuiz();
                stDirQuiz = _context.StudentDirectionQuizzes.
                       FirstOrDefault(u => u.Username == username && u.IdDirection == 4);

                stDirQuiz.Score = score;
                _context.Update(stDirQuiz);
                _context.SaveChanges();
                return RedirectToAction("UxDesignerDirection", "Students");
            }
            else
            {
                return RedirectToAction("StudentsLogin", "Students");
            }
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.Any, NoStore = true)]
        public IActionResult AiSpecialistQuiz()
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
        public async Task<IActionResult> AiSpecialistQuiz(int score)
        {

            if (HttpContext.Session.GetString("username") != null)
            {
                String username = HttpContext.Session.GetString("username");
                StudentDirectionQuiz stDirQuiz = new StudentDirectionQuiz();
                stDirQuiz = _context.StudentDirectionQuizzes.
                       FirstOrDefault(u => u.Username == username && u.IdDirection == 5);

                stDirQuiz.Score = score;
                _context.Update(stDirQuiz);
                _context.SaveChanges();
                return RedirectToAction("AiSpecialistDirection", "Students");
            }
            else
            {
                return RedirectToAction("StudentsLogin", "Students");
            }
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.Any, NoStore = true)]
        public IActionResult WebDeveloperQuiz()
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
        public async Task<IActionResult> WebDeveloperQuiz(int score)
        {

            if (HttpContext.Session.GetString("username") != null)
            {
                String username = HttpContext.Session.GetString("username");
                StudentDirectionQuiz stDirQuiz = new StudentDirectionQuiz();
                stDirQuiz = _context.StudentDirectionQuizzes.
                       FirstOrDefault(u => u.Username == username && u.IdDirection == 6);

                stDirQuiz.Score = score;
                _context.Update(stDirQuiz);
                _context.SaveChanges();
                return RedirectToAction("WebDeveloperDirection", "Students");
            }
            else
            {
                return RedirectToAction("StudentsLogin", "Students");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.Any, NoStore = true)]
        public IActionResult RepeatQuiz()
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
        public async Task<IActionResult> RepeatQuiz(int score)
        {

            if (HttpContext.Session.GetString("username") != null)
            {
                String username = HttpContext.Session.GetString("username");
                StudentRepeatQuiz stRepeatQuiz = new StudentRepeatQuiz();
                stRepeatQuiz = _context.StudentRepeatQuizzes.
                       FirstOrDefault(u => u.Username == username && u.Id == 1);

                stRepeatQuiz.Score = score;
                _context.Update(stRepeatQuiz);
                _context.SaveChanges();
                return RedirectToAction("StudentHome", "Students");
            }
            else
            {
                return RedirectToAction("StudentsLogin", "Students");
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.Any, NoStore = true)]
        public async Task<IActionResult> InsertGrades()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                String username = HttpContext.Session.GetString("username");
                var StudentLessons = _context.StudentGrades.Include(s => s.IdCourseNavigation).Where(s => s.Username.Equals(username));


                return View(await StudentLessons.ToListAsync());
            }
            else
            {
                return RedirectToAction("StudentsLogin", "Students");
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertGrades(int SelectedCourseId, int grade)
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                String username = HttpContext.Session.GetString("username");          

                StudentGrade studentGrade = new StudentGrade();

                studentGrade = _context.StudentGrades.
                    FirstOrDefault(u => u.IdCourse == SelectedCourseId && u.Username == username);

                studentGrade.Grade = grade;
                _context.Update(studentGrade);
                _context.SaveChanges();

                var StudentLessons = _context.StudentGrades.Include(s => s.IdCourseNavigation).Where(s => s.Username.Equals(username));
                return View(await StudentLessons.ToListAsync());
            }
            else
            {
                return RedirectToAction("UsersLogin", "Users");
            }

        }
    }
}

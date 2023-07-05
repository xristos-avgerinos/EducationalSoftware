using EducationalSoftware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Diagnostics;
using System.Collections.Generic;

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
                String username = HttpContext.Session.GetString("username");

                var completedDirections = _context.StudentDirectionQuizzes.
                    Where(u => u.Username == username && u.Score != null).Select(s => s.IdDirection);

                ViewBag.completedDirections = completedDirections.ToList();

                var gradedLessonsDb = _context.StudentGrades.Where(u => u.Username == username && u.Grade != null).Select(s=>s.Grade);
                var avg = gradedLessonsDb.Average();
                ViewBag.avgGradedLessons = Math.Round((double)avg, 2);
                ViewBag.gradedLessons = gradedLessonsDb.Count();

                var avgQuizzes = _context.StudentDirectionQuizzes.
                    Where(u => u.Username == username && u.Score != null).Select(s => s.Score).Average();  

                ViewBag.scoreAvgQuizzes = Math.Round((double)avgQuizzes, 2);
               
                int RecommendationQuizCount = _context.StudentRecommendationQuizzes.
                    Where(u => u.Username == username && u.Score != null).Count();

                if (RecommendationQuizCount == 6)
                {
                    ViewBag.RecommendationQuizDone = "true";
                }
                else
                { 
                    ViewBag.RecommendationQuizDone = "false";
                }
                
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
                StudentDirectionTraffic studentDirTraffic = new StudentDirectionTraffic();

                studentDirTraffic = _context.StudentDirectionTraffics.
                    FirstOrDefault(u => u.IdDirection == 1 && u.Username == username);

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
                return RedirectToAction("StudentsLogin", "Students");
            }

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.Any, NoStore = true)]
        public IActionResult RecommendationQuiz()
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
        public async Task<IActionResult> RecommendationQuiz(int Dir1score, int Dir2score, int Dir3score, int Dir4score, int Dir5score, int Dir6score)
        {

            if (HttpContext.Session.GetString("username") != null)
            {
                String username = HttpContext.Session.GetString("username");
                int[] DirScores = { Dir1score , Dir2score , Dir3score , Dir4score , Dir5score , Dir6score };

                for (int i = 0; i < 6; i++) {

                    StudentRecommendationQuiz stRecommendationDIRi = new StudentRecommendationQuiz();
                    stRecommendationDIRi = _context.StudentRecommendationQuizzes.
                           FirstOrDefault(u => u.Username == username && u.IdDirection == i+1);

                    stRecommendationDIRi.Score = DirScores[i];
                    _context.Update(stRecommendationDIRi);
                    _context.SaveChanges();

                }

               
                return RedirectToAction("SystemRecommendation", "Students");
            }
            else
            {
                return RedirectToAction("StudentsLogin", "Students");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.Any, NoStore = true)]
        public IActionResult SystemRecommendation()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                String username = HttpContext.Session.GetString("username");

                double[] DirectionsRecommendationScore = new double[6];
                double finalScoreDIRi;

                for (int i = 0; i < 6; i++)
                {
                    //sto quiz systasevn dinv baros 30% gia tis telikes systaseiw poy tha prokipsoyn apo to sistima gia kathe kateythinsi
                    var RecommendationScoreDIRi = _context.StudentRecommendationQuizzes.
                    FirstOrDefault(u => u.Username == username && u.IdDirection == i+1).Score;

                    finalScoreDIRi = ((double)RecommendationScoreDIRi * 30) / 100;

                    //sto quiz tis kathe kateythinsis dinv baros 30% gia tis telikes systaseiw poy tha prokipsoyn apo to sistima
                    var quizScoreDIRi = _context.StudentDirectionQuizzes.FirstOrDefault(u => u.Username == username && u.IdDirection == i + 1).Score;
                    finalScoreDIRi += ((double)quizScoreDIRi * 30) / 100;

                    //sto MO apo ta bathmologimena mathimata toy foititi kathe kateythinsis dinv baros 20% gia tis telikes systaseiw poy tha prokipsoyn apo to sistima
                    var AvgGradedCoursesDIRi = _context.StudentGrades.Include(s => s.IdCourseNavigation).Where(s => s.Username == username && s.IdCourseNavigation.IdDirection == i + 1 && s.Grade != null).Select(s => s.Grade).Average();
                    if (AvgGradedCoursesDIRi == null) {
                        AvgGradedCoursesDIRi = 0;
                    }
                    finalScoreDIRi += ((double)AvgGradedCoursesDIRi * 20) / 10;

                    //sto traffic kathe kateythinsis dinv baros to ypoloipo 20% gia tis telikes systaseiw poy tha prokipsoyn apo to sistima
                    var maxDirTraffic = _context.StudentDirectionTraffics.Where(s=>s.Username == username).Select(s => s.Traffic).Max();
                    var trafficDIRi = _context.StudentDirectionTraffics.FirstOrDefault(s => s.Username == username && s.IdDirection == i + 1).Traffic;
                    finalScoreDIRi += ((double)trafficDIRi/(double)maxDirTraffic) * 20 ;

                    DirectionsRecommendationScore[i] = Math.Round((double)finalScoreDIRi, 2);
                }

                ViewBag.DirectionsRecommendationScore = DirectionsRecommendationScore;

                Dictionary<int, string> indexStringMap = new Dictionary<int, string>();
                // Add entries to the map
                indexStringMap.Add(0, "Ειδικός Ανάλυσης Δεδομένων");
                indexStringMap.Add(1, "Ειδικός Ασφάλειας και Προστασίας Δεδομένων");
                indexStringMap.Add(2, "Μηχανικός Λογισμικού");
                indexStringMap.Add(3, "Σχεδιαστής Εμπειρίας Χρηστών");
                indexStringMap.Add(4, "Ειδικός Μηχανικής Μάθησης και Τεχνητής Νοημοσύνης");
                indexStringMap.Add(5, "Προγραμματιστής Web");

                double max = DirectionsRecommendationScore.Max();
                var maxIndices = Enumerable.Range(0, DirectionsRecommendationScore.Length)
                                           .Where(i => DirectionsRecommendationScore[i] == max)
                                           .ToList();

                String[] maxPercentagesDirTitles = new string[maxIndices.Count];
                int x = 0;
                foreach (int index in maxIndices)
                {
                    maxPercentagesDirTitles[x] = indexStringMap[index];
                    x++;
                }
                ViewBag.maxPercentagesDirTitles = maxPercentagesDirTitles;

                return View();
            }
            else
            {
                return RedirectToAction("StudentsLogin", "Students");
            }
        }
        

        public IActionResult Logout()
        {
            return RedirectToAction("StudentsLogin", "Students");
        }
    }
}

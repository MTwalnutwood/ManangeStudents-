using Microsoft.AspNetCore.Mvc;

using WebApplication10.Dbset;

using WebApplication10.Models;
using System.Linq;
namespace WebApplication10.Controllers

{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index)); 
            }
            return View(student);
        }

        public IActionResult Statistics()
        {
            var allStudents = _context.Students.ToList();
            var average = Math.Round(allStudents.Average(s => s.CalculateAverage()), 2);
            var highestGrade = allStudents.Max(s => s.CalculateAverage());
            var lowestGrade = allStudents.Min(s => s.CalculateAverage());
            var passingAverage = Math.Round((double)allStudents.Count(s => s.CalculateAverage() >= 10) / allStudents.Count() * 100, 2);

            ViewBag.Average = average;
            ViewBag.Highest = highestGrade;
            ViewBag.Lowest = lowestGrade;
            ViewBag.PassingAverage = passingAverage;

            return View();
        }
    }
}
   

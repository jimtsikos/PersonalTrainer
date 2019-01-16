using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Application.Lessons.Service;
using Application.Students.Service;
using Application.Trainers.Service;
using Application.Lessons.Dtos;
using DomainModel.LessonImpl.Enum;
using Extensions.Enumarations;

namespace PersonalTrainer.WebApp.Core.Controllers
{
    public class LessonsController : Controller
    {
        private readonly ILessonService _lessonService;
        private readonly ITrainerService _trainerService;
        private readonly IStudentService _studentService;
        private readonly IEnumService _enumService;

        public LessonsController(ILessonService lessonService, 
                                 ITrainerService trainerService, 
                                 IStudentService studentService,
                                 IEnumService enumService)
        {
            _lessonService = lessonService;
            _trainerService = trainerService;
            _studentService = studentService;
            _enumService = enumService;
        }

        // GET: Lessons
        public IActionResult Index()
        {
            var lessonList = _lessonService.GetList().ToList();
            lessonList.ForEach(x =>
            {
                var trainer = _trainerService.Get(x.TrainerId);
                var student = _studentService.Get(x.StudentId);
                ViewData[string.Format("Trainer_", Convert.ToString(x.Id))] = string.Format("{0} {1}", trainer.FirstName, trainer.LastName);
                ViewData[string.Format("Student_", Convert.ToString(x.Id))] = string.Format("{0} {1}", student.FirstName, student.LastName);
            });
            return View(lessonList);
        }

        // GET: Lessons/Details/5
        public IActionResult Details(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }

            var lesson = _lessonService.Get(id);

            var trainer = _trainerService.Get(lesson.TrainerId);
            var student = _studentService.Get(lesson.StudentId);
            ViewData[string.Format("Trainer_", Convert.ToString(trainer.Id))] = string.Format("{0} {1}", trainer.FirstName, trainer.LastName);
            ViewData[string.Format("Student_", Convert.ToString(student.Id))] = string.Format("{0} {1}", student.FirstName, student.LastName);

            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // GET: Lessons/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_studentService.GetList(), "Id", "LastName");

            ViewData["TrainerId"] = new SelectList(_trainerService.GetList(), "Id", "LastName");

            var hours = from Hour d in Enum.GetValues(typeof(Hour))
                          select new { Id = (int)d, Name = _enumService.GetDescription(d) };
            ViewData["Hours"] = new SelectList(hours, "Id", "Name");

            var minutes = from Minutes d in Enum.GetValues(typeof(Minutes))
                             select new { Id = (int)d, Name = _enumService.GetDescription(d) };
            ViewData["Minutes"] = new SelectList(minutes, "Id", "Name");
            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,StudentId,TrainerId,DateTime,Hour,Minutes,IsActive,IsPaid")] LessonDto lesson)
        {
            if (ModelState.IsValid)
            {
                _lessonService.Create(lesson);
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_studentService.GetList(), "Id", "LastName");
            ViewData["TrainerId"] = new SelectList(_trainerService.GetList(), "Id", "LastName");
            return View(lesson);
        }

        // GET: Lessons/Edit/5
        public IActionResult Edit(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }

            var lesson = _lessonService.Get(id);
            if (lesson == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_studentService.GetList(), "Id", "LastName");
            ViewData["TrainerId"] = new SelectList(_trainerService.GetList(), "Id", "LastName");
            return View(lesson);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,StudentId,TrainerId,DateTime,Hour,Minutes,IsActive,IsPaid")] LessonDto lesson)
        {
            if (id != lesson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _lessonService.Update(lesson);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonExists(lesson.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_studentService.GetList(), "Id", "LastName");
            ViewData["TrainerId"] = new SelectList(_trainerService.GetList(), "Id", "LastName");
            return View(lesson);
        }

        // GET: Lessons/Delete/5
        public IActionResult Delete(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }

            var lesson = _lessonService.Get(id);

            var trainer = _trainerService.Get(lesson.TrainerId);
            var student = _studentService.Get(lesson.StudentId);
            ViewData[string.Format("Trainer_", Convert.ToString(trainer.Id))] = string.Format("{0} {1}", trainer.FirstName, trainer.LastName);
            ViewData[string.Format("Student_", Convert.ToString(student.Id))] = string.Format("{0} {1}", student.FirstName, student.LastName);

            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _lessonService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool LessonExists(Guid id)
        {
            return _lessonService.GetList().Any(e => e.Id == id);
        }
    }
}

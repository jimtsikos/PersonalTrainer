using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Application.Lessons.Service;
using Application.Students.Service;
using Application.Trainers.Service;
using Application.Lessons.Dtos;
using Application.Extensions.Enumarations;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Application.Handlers;
using PersonalTrainer.WebApp.Core.Models;
using Application.Students.Dtos;
using Application.Trainers.Dtos;

namespace PersonalTrainer.WebApp.Core.Controllers
{
    [Authorize(Roles = "System Administrator,Administrator,Moderator,Trainer")]
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
            var lessonList = _lessonService.GetList();

            ResultViewModel<IEnumerable<LessonDto>> lessonsViewModel =
                AutoMapper.Mapper.Map<ResultHandler<IEnumerable<LessonDto>>, ResultViewModel<IEnumerable<LessonDto>>>(lessonList);

            return View(lessonsViewModel);   
        }

        // GET: Lessons/Details/5
        public IActionResult Details(Guid id)
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

            ResultViewModel<LessonDto> lessonViewModel =
                AutoMapper.Mapper.Map<ResultHandler<LessonDto>, ResultViewModel<LessonDto>>(lesson);

            return View(lessonViewModel);
        }

        // GET: Lessons/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_studentService.GetList().Data, "Id", "LastName");
            ViewData["TrainerId"] = new SelectList(_trainerService.GetList().Data, "Id", "LastName");
            ViewData["Hours"] = new SelectList(_enumService.GetHoursList(), "Id", "Name");
            ViewData["Minutes"] = new SelectList(_enumService.GetMinutesList(), "Id", "Name");
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
            ViewData["StudentId"] = new SelectList(_studentService.GetList().Data, "Id", "LastName");
            ViewData["TrainerId"] = new SelectList(_trainerService.GetList().Data, "Id", "LastName");
            return View();
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
            ViewData["StudentId"] = new SelectList(_studentService.GetList().Data, "Id", "LastName");
            ViewData["TrainerId"] = new SelectList(_trainerService.GetList().Data, "Id", "LastName");
            ViewData["Hours"] = new SelectList(_enumService.GetHoursList(), "Id", "Name", lesson.Data.Hour);
            ViewData["Minutes"] = new SelectList(_enumService.GetMinutesList(), "Id", "Name", lesson.Data.Minutes);

            ResultViewModel<LessonDto> lessonViewModel =
                AutoMapper.Mapper.Map<ResultHandler<LessonDto>, ResultViewModel<LessonDto>>(lesson);

            return View(lessonViewModel);
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
            ViewData["StudentId"] = new SelectList(_studentService.GetList().Data, "Id", "LastName");
            ViewData["TrainerId"] = new SelectList(_trainerService.GetList().Data, "Id", "LastName");
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
            if (lesson == null)
            {
                return NotFound();
            }

            ResultViewModel<LessonDto> lessonViewModel =
                AutoMapper.Mapper.Map<ResultHandler<LessonDto>, ResultViewModel<LessonDto>>(lesson);

            return View(lessonViewModel);
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
            return _lessonService.GetList().Data.Any(e => e.Id == id);
        }
    }
}

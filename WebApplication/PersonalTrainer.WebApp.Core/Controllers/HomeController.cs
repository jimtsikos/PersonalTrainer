using Application.Handlers;
using Application.Lessons.Dtos;
using Application.Lessons.Service;
using Application.Students.Service;
using Application.Trainers.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalTrainer.WebApp.Core.Models;
using System;

namespace PersonalTrainer.WebApp.Core.Controllers
{
    [Authorize(Roles = "System Administrator,Administrator,Moderator,Trainer")]
    public class HomeController : Controller
    {
        private readonly ITrainerService _trainerService;
        private readonly IStudentService _studentService;
        private readonly ILessonService _lessonService;

        public HomeController(ITrainerService trainerService,
                                 IStudentService studentService,
                                 ILessonService lessonService)
        {
            _trainerService = trainerService;
            _studentService = studentService;
            _lessonService = lessonService;
        }

        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel()
            {
                TotalTrainers = _trainerService.Count(),
                TotalStudents = _studentService.Count(),
                TotalLessons = _lessonService.Count(),
                YesterdayLessons = _lessonService.GetByDate(DateTime.UtcNow.AddDays(-1)).Data,
                TodayLessons = _lessonService.GetByDate(DateTime.UtcNow).Data
            };

            return View(homeViewModel);
        }

        public IActionResult MarkAsCompleted(Guid lessonId)
        {
            ResultHandler<LessonDto> resultHandler = _lessonService.MarkAsCompleted(lessonId);
            if (!resultHandler.HasErrors)
            {
                _studentService.PayLesson(resultHandler.Data.StudentId);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
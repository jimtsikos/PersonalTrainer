﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application.Students.Service;
using Application.Students.Dtos;
using Microsoft.AspNetCore.Authorization;
using PersonalTrainer.WebApp.Core.Models;
using System.Collections.Generic;
using Application.Handlers;
using Application.Extensions.Paging;

namespace PersonalTrainer.WebApp.Core.Controllers
{
    [Authorize(Roles = "System Administrator,Administrator,Moderator,Trainer")]
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: Students
        public IActionResult Index(string searchString, int? page)
        {
            ResultHandler<PaginatedList<StudentDto>> students;

            if (!String.IsNullOrEmpty(searchString))
            {
                students = _studentService.GetList(searchString);
            }
            else
            {
                students = _studentService.GetList();
            }

            page = page != null ? page : 1;
            int pageSize = 10;
            students.Data = PaginatedList<StudentDto>.Create(students.Data.AsQueryable(), page ?? 1, pageSize);

            ResultViewModel<PaginatedList<StudentDto>> studentsViewModel =
                AutoMapper.Mapper.Map<ResultHandler<PaginatedList<StudentDto>>, ResultViewModel<PaginatedList<StudentDto>>>(students);

            return View(studentsViewModel);
        }

        // GET: Students/Details/5
        public IActionResult Details(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }

            var student = _studentService.Get(id);
            if (student == null)
            {
                return NotFound();
            }

            ResultViewModel<StudentDto> studentViewModel =
                AutoMapper.Mapper.Map<ResultHandler<StudentDto>, ResultViewModel<StudentDto>>(student);

            return View(studentViewModel);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,FirstName,LastName,Description,Height,PayRate,PrepaidMoney,IsActive")] StudentDto student)
        {
            if (ModelState.IsValid)
            {
                _studentService.Create(student);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Students/Edit/5
        public IActionResult Edit(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }

            var student = _studentService.Get(id);
            if (student == null)
            {
                return NotFound();
            }

            ResultViewModel<StudentDto> studentViewModel =
                AutoMapper.Mapper.Map<ResultHandler<StudentDto>, ResultViewModel<StudentDto>>(student);

            return View(studentViewModel);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,FirstName,LastName,Description,Height,PayRate,PrepaidMoney,IsActive")] StudentDto student)
        {
            ResultHandler<StudentDto> resultHandler = new ResultHandler<StudentDto>();

            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    resultHandler = _studentService.Update(student);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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

            ResultViewModel<StudentDto> studentViewModel =
                AutoMapper.Mapper.Map<ResultHandler<StudentDto>, ResultViewModel<StudentDto>>(resultHandler);

            return View(studentViewModel);
        }

        // GET: Students/Delete/5
        public IActionResult Delete(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }

            var student = _studentService.Get(id);
            if (student == null)
            {
                return NotFound();
            }

            ResultViewModel<StudentDto> studentViewModel =
                AutoMapper.Mapper.Map<ResultHandler<StudentDto>, ResultViewModel<StudentDto>>(student);

            return View(studentViewModel);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _studentService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(Guid id)
        {
            return _studentService.GetList().Data.Any(e => e.Id == id);
        }
    }
}

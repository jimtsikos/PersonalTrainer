﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Application.StudentWeights.Service;
using Application.Students.Service;
using Application.StudentWeights.Dtos;
using Microsoft.AspNetCore.Authorization;
using PersonalTrainer.WebApp.Core.Models;
using System.Collections.Generic;
using Application.Handlers;
using Application.Extensions.Paging;

namespace PersonalTrainer.WebApp.Core.Controllers
{
    [Authorize(Roles = "System Administrator,Administrator,Moderator,Trainer")]
    public class StudentWeightsController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IStudentWeightsService _studentWeightsService;

        public StudentWeightsController(IStudentService studentService, IStudentWeightsService studentWeightsService)
        {
            _studentService = studentService;
            _studentWeightsService = studentWeightsService;
        }

        // GET: StudentWeights
        public IActionResult Index(Guid studentId, int? page)
        {
            ViewData["SelectedStudent"] = studentId;
            var students = _studentService.GetList();
            ViewData["Student"] = new SelectList(students.Data, "Id", "LastName", studentId);

            Pageable pageable = new Pageable() { Page = page != null ? (int)page : 1, PageSize = 10 };
            var studentWeights = _studentWeightsService.GetList(studentId, pageable);

            ResultViewModel<PaginatedList<StudentWeightDto>> resultViewModel =
                AutoMapper.Mapper.Map<ResultHandler<PaginatedList<StudentWeightDto>>, ResultViewModel<PaginatedList<StudentWeightDto>>>(studentWeights);

            return View(resultViewModel);
        }

        // GET: StudentWeights/Details/5
        public IActionResult Details(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }

            var studentWeight = _studentWeightsService.Get(id);
            if (studentWeight == null)
            {
                return NotFound();
            }

            ResultViewModel<StudentWeightDto> resultViewModel =
                AutoMapper.Mapper.Map<ResultHandler<StudentWeightDto>, ResultViewModel<StudentWeightDto>>(studentWeight);

            return View(resultViewModel);
        }

        // GET: StudentWeights/Create
        public IActionResult Create(Guid studentId)
        {
            ViewData["StudentId"] = new SelectList(_studentService.GetList().Data, "Id", "LastName", studentId);
            return View();
        }

        // POST: StudentWeights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,StudentId,Weight", Prefix = "Data")] StudentWeightDto studentWeight)
        {
            ResultHandler<StudentWeightDto> resultHandler = new ResultHandler<StudentWeightDto>();

            if (ModelState.IsValid)
            {
                resultHandler = _studentWeightsService.Create(studentWeight);
                if (!resultHandler.HasErrors)
                {
                    return RedirectToAction(nameof(Index), new { studentId = studentWeight.StudentId });
                }
            }

            ViewData["StudentId"] = new SelectList(_studentService.GetList().Data, "Id", "LastName", studentWeight.StudentId);
            ResultViewModel<StudentWeightDto> resultViewModel =
                AutoMapper.Mapper.Map<ResultHandler<StudentWeightDto>, ResultViewModel<StudentWeightDto>>(resultHandler);

            return View(resultViewModel);
        }

        // GET: StudentWeights/Edit/5
        public IActionResult Edit(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }

            var studentWeight = _studentWeightsService.Get(id);
            if (studentWeight == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_studentService.GetList().Data, "Id", "LastName", studentWeight.Data.StudentId);

            ResultViewModel<StudentWeightDto> resultViewModel =
                AutoMapper.Mapper.Map<ResultHandler<StudentWeightDto>, ResultViewModel<StudentWeightDto>>(studentWeight);

            return View(resultViewModel);
        }

        // POST: StudentWeights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,StudentId,Weight", Prefix = "Data")] StudentWeightDto studentWeight)
        {
            ResultHandler<StudentWeightDto> resultHandler = new ResultHandler<StudentWeightDto>();

            if (id != studentWeight.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    resultHandler = _studentWeightsService.Update(studentWeight);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentWeightExists(studentWeight.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { studentId = studentWeight.StudentId });
            }
            ViewData["StudentId"] = new SelectList(_studentService.GetList().Data, "Id", "LastName", studentWeight.StudentId);

            ResultViewModel<StudentWeightDto> resultViewModel =
                AutoMapper.Mapper.Map<ResultHandler<StudentWeightDto>, ResultViewModel<StudentWeightDto>>(resultHandler);

            return View(resultViewModel);
        }

        // GET: StudentWeights/Delete/5
        public IActionResult Delete(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }

            var studentWeight = _studentWeightsService.Get(id);
            if (studentWeight == null)
            {
                return NotFound();
            }

            ResultViewModel<StudentWeightDto> resultViewModel =
                AutoMapper.Mapper.Map<ResultHandler<StudentWeightDto>, ResultViewModel<StudentWeightDto>>(studentWeight);

            return View(resultViewModel);
        }

        // POST: StudentWeights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            ResultHandler<StudentWeightDto> resultHandler = _studentWeightsService.Delete(id);
            return RedirectToAction(nameof(Index), new { studentId = resultHandler.Data.StudentId });
        }

        private bool StudentWeightExists(Guid id)
        {
            return _studentWeightsService.GetList().Data.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.DAL;
using DomainModel.StudentWeightsImpl;
using Application.StudentWeights.Service;
using Application.Students.Service;
using Application.StudentWeights.Dtos;

namespace PersonalTrainer.WebApp.Core.Controllers
{
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
        public IActionResult Index(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                var studentWeightsList = _studentWeightsService.GetList().ToList();
                studentWeightsList.ForEach(x =>
                {
                    var student = _studentService.Get(x.StudentId);
                    ViewData[Convert.ToString(x.Id)] = string.Format("{0} {1}", student.FirstName, student.LastName);
                });
                return View(studentWeightsList);
            }
            else
            {
                var studentWeightsList = _studentWeightsService.GetList(id).ToList();
                studentWeightsList.ForEach(x =>
                {
                    var student = _studentService.Get(x.StudentId);
                    ViewData[Convert.ToString(x.Id)] = string.Format("{0} {1}", student.FirstName, student.LastName);
                });
                return View(studentWeightsList);
            }
        }

        // GET: StudentWeights/Details/5
        public IActionResult Details(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }

            var studentWeight = _studentWeightsService.Get(id);
            var student = _studentService.Get(studentWeight.StudentId);
            ViewData[Convert.ToString(student.Id)] = string.Format("{0} {1}", student.FirstName, student.LastName);
            if (studentWeight == null)
            {
                return NotFound();
            }

            return View(studentWeight);
        }

        // GET: StudentWeights/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_studentService.GetList(), "Id", "LastName");
            return View();
        }

        // POST: StudentWeights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,StudentId,Weight")] StudentWeightDto studentWeight)
        {
            if (ModelState.IsValid)
            {
                _studentWeightsService.Create(studentWeight);
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_studentService.GetList(), "Id", "LastName");
            return View(studentWeight);
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
            ViewData["StudentId"] = new SelectList(_studentService.GetList(), "Id", "LastName");
            return View(studentWeight);
        }

        // POST: StudentWeights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,StudentId,Weight")] StudentWeightDto studentWeight)
        {
            if (id != studentWeight.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _studentWeightsService.Update(studentWeight);
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_studentService.GetList(), "Id", "LastName");
            return View(studentWeight);
        }

        // GET: StudentWeights/Delete/5
        public IActionResult Delete(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }

            var studentWeight = _studentWeightsService.Get(id);
            var student = _studentService.Get(studentWeight.StudentId);
            ViewData[Convert.ToString(student.Id)] = string.Format("{0} {1}", student.FirstName, student.LastName);
            if (studentWeight == null)
            {
                return NotFound();
            }

            return View(studentWeight);
        }

        // POST: StudentWeights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _studentWeightsService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool StudentWeightExists(Guid id)
        {
            return _studentWeightsService.GetList().Any(e => e.Id == id);
        }
    }
}

using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application.Trainers.Service;
using Application.Trainers.Dtos;
using Microsoft.AspNetCore.Authorization;
using Application.Extensions.Paging;
using PersonalTrainer.WebApp.Core.Models;
using Application.Handlers;

namespace PersonalTrainer.WebApp.Core.Controllers
{
    [Authorize(Roles = "System Administrator,Administrator,Moderator,Trainer")]
    public class TrainersController : Controller
    {
        private readonly ITrainerService _trainerService;

        public TrainersController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        // GET: Trainers
        public IActionResult Index(string searchString, int? page)
        {
            ResultHandler<PaginatedList<TrainerDto>> trainers;
            Pageable pageable = new Pageable() { Page = page != null ? (int)page : 1, PageSize = 10 };

            if (!String.IsNullOrEmpty(searchString))
            {
                trainers = _trainerService.GetList(searchString, pageable);
            }
            else
            {
                trainers = _trainerService.GetList(pageable);
            }
            
            ResultViewModel<PaginatedList<TrainerDto>> resultViewModel =
                AutoMapper.Mapper.Map<ResultHandler<PaginatedList<TrainerDto>>, ResultViewModel<PaginatedList<TrainerDto>>>(trainers);

            return View(resultViewModel);
        }

        // GET: Trainers/Details/5
        public IActionResult Details(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }

            var trainer = _trainerService.Get(id);
            if (trainer == null)
            {
                return NotFound();
            }

            ResultViewModel<TrainerDto> resultViewModel =
                AutoMapper.Mapper.Map<ResultHandler<TrainerDto>, ResultViewModel<TrainerDto>>(trainer);

            return View(resultViewModel);
        }

        // GET: Trainers/Create
        public IActionResult Create()
        {
            return View(new ResultViewModel<TrainerDto>());
        }

        // POST: Trainers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,FirstName,LastName,Description,PayRate,IsActive", Prefix = "Data")] TrainerDto trainer)
        {
            ResultHandler<TrainerDto> resultHandler = new ResultHandler<TrainerDto>();

            if (ModelState.IsValid)
            {
                resultHandler = _trainerService.Create(trainer);
                if (!resultHandler.HasErrors)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            ResultViewModel<TrainerDto> resultViewModel = 
                AutoMapper.Mapper.Map<ResultHandler<TrainerDto>, ResultViewModel<TrainerDto>>(resultHandler);
            return View(resultViewModel);
        }

        // GET: Trainers/Edit/5
        public IActionResult Edit(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }

            var trainer = _trainerService.Get(id);
            if (trainer == null)
            {
                return NotFound();
            }

            ResultViewModel<TrainerDto> resultViewModel =
                AutoMapper.Mapper.Map<ResultHandler<TrainerDto>, ResultViewModel<TrainerDto>>(trainer);

            return View(resultViewModel);
        }

        // POST: Trainers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,FirstName,LastName,Description,PayRate,IsActive", Prefix = "Data")] TrainerDto trainer)
        {
            ResultHandler<TrainerDto> resultHandler = new ResultHandler<TrainerDto>();

            if (id != trainer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    resultHandler = _trainerService.Update(trainer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainerExists(trainer.Id))
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

            ResultViewModel<TrainerDto> resultViewModel =
                AutoMapper.Mapper.Map<ResultHandler<TrainerDto>, ResultViewModel<TrainerDto>>(resultHandler);

            return View(resultViewModel);
        }

        // GET: Trainers/Delete/5
        public IActionResult Delete(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }

            var trainer = _trainerService.Get(id);
            if (trainer == null)
            {
                return NotFound();
            }

            ResultViewModel<TrainerDto> resultViewModel =
                AutoMapper.Mapper.Map<ResultHandler<TrainerDto>, ResultViewModel<TrainerDto>>(trainer);

            return View(resultViewModel);
        }

        // POST: Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _trainerService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TrainerExists(Guid id)
        {
            return _trainerService.GetList().Data.Any(e => e.Id == id);
        }
    }
}

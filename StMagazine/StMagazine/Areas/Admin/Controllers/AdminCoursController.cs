using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StMagazine.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using StMagazine.Interfaces;
using StMagazine.ViewModels.CViewModel;
using StMagazine.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace StMagazine.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "admin")]
    public class AdminCoursController : Controller
    {
        private readonly ICoursRepository _coursRepository;

        public AdminCoursController(ICoursRepository coursRepository)
        {
            _coursRepository = coursRepository;
        }
        public ViewResult Index(string Number, int page = 1)
        {
            IEnumerable<Cours> courses = _coursRepository.GetAllCourses();
            if (!String.IsNullOrEmpty(Number))
                courses = courses.Where(n => n.CoursNumber.ToString().Contains(Number));
            int pageSize = 3;
            var count = courses.Count();
            var skip = courses.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            CoursViewModel cvm = new CoursViewModel(skip, pageViewModel);
            return View(cvm);
        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (id != null)
            {
                Cours cours = _coursRepository.GetCoursId(id);
                CoursDeleteViewModel coursDeleteViewModel = new CoursDeleteViewModel
                {
                    Number = cours.CoursNumber,
                    Id = cours.Id,
                    Groups = cours.Groups
                };
                return View(coursDeleteViewModel);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Cours cours = _coursRepository.GetCoursId(id);
            if (cours != null)
            {
                _coursRepository.Delete(id);
                return RedirectToAction("Index");
            };
            return NotFound();
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CoursCreateViewModel coursCreateViewModel)
        {
            if (coursCreateViewModel != null)
            {
                Cours newCours = new Cours
                {
                    CoursNumber = coursCreateViewModel.Number,
                    Groups = coursCreateViewModel.Groups
                };
                _coursRepository.Add(newCours);
                return RedirectToAction("Index", new { id = newCours.Id });
            };
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id != null)
            {
                Cours cours = _coursRepository.GetCoursId(id);
                CoursEditViewModel coursEditViewModel = new CoursEditViewModel
                {
                    Id = cours.Id,
                    Number = cours.CoursNumber,
                    Groups = cours.Groups
                };
                return View(coursEditViewModel);
            }
            return NotFound();
        }
        [HttpPost]
        [Obsolete]
        public async Task<IActionResult> Edit(CoursEditViewModel model)
        {
            Cours cours = _coursRepository.GetCoursId(model.Id);
            cours.CoursNumber = model.Number;
            cours.Groups = model.Groups;
            _coursRepository.Update(cours);
            return RedirectToAction("Index");
        }


    }
}

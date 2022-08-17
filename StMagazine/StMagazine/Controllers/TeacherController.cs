using Microsoft.AspNetCore.Mvc;
using StMagazine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using StMagazine.ViewModels;
using StMagazine.Interfaces;
using StMagazine.SQLRepository;
using StMagazine.ViewModels.TViewModel;
using Microsoft.AspNetCore.Authorization;

namespace StMagazine.Controllers
{ 
    public class TeacherController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment; 
        private readonly ITeacherRepository _teacherRepository;
        private readonly IItemRepository _itemRepository;


        public TeacherController(ITeacherRepository teacherRepository, IItemRepository itemRepository,
            IHostingEnvironment hostingEnvironment)
        {
            _teacherRepository = teacherRepository;
            _itemRepository = itemRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        public ViewResult Index(string Name, int page = 1)
        {
            IEnumerable<Teacher> teachers = _teacherRepository.GetAllTeacher();
            IEnumerable<Item> items = _itemRepository.GetAllItems().ToList();
            if (!String.IsNullOrEmpty(Name))
                teachers = teachers.Where(n => (n.Name + " " + n.Surname).Contains(Name));

            int pageSize = 2;
            var count = teachers.Count();
            var skip = teachers.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            TeacherViewModel tvm = new TeacherViewModel(skip, pageViewModel);
            
            return View(tvm);
        }
        public IActionResult Create()
        {
            ViewBag.Items = new SelectList(_itemRepository.GetAllItems(), "Id", "ItemName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TeacherCreateViewModel model)
        {
            string uniqueFileName = ProcessUploadFile(model);
            Teacher teacher = new Teacher
            {
                Name = model.Name,
                Surname = model.Surname,
                PhoneNumber = model.PhoneNumber,
                Groups = model.Groups,
                ItemId = model.ItemId,
                Item = model.Item,
                PhotoPath = uniqueFileName,   
            };
            _teacherRepository.Add(teacher);
            return RedirectToAction("Index", new { Id = teacher.Id });
        }

        //DELETE
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (id != null)
            {
                Teacher teacher = _teacherRepository.GetAllTeacher().FirstOrDefault(p => p.Id == id);
                TeacherDeleteViewModel teacherDeleteViewModel = new TeacherDeleteViewModel
                {
                    Id = teacher.Id,
                    Name = teacher.Name,
                    Surname = teacher.Surname,
                    PhoneNumber = teacher.PhoneNumber,
                    Groups = teacher.Groups,
                    ItemId = teacher.ItemId,
                    Item = teacher.Item,
                    ExistingPhotoPath = teacher.PhotoPath
                };
                return View(teacherDeleteViewModel);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (id != null)
            {
                Teacher teacher = _teacherRepository.GetTeacherId(id);
                if (teacher != null)
                {
                    _teacherRepository.Delete(id);
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
         //EDIT
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id != null)
            {
                Teacher teacher = _teacherRepository.GetTeacherId(id);
                TeacherEditViewModel teacherEditViewModel = new TeacherEditViewModel
                {
                    Id = teacher.Id,
                    Name = teacher.Name,
                    Surname = teacher.Surname,
                    PhoneNumber = teacher.PhoneNumber,
                    Groups = teacher.Groups,
                    ItemId = teacher.ItemId,
                    Item = teacher.Item,
                    ExistingPhotoPath=teacher.PhotoPath
                };
                ViewBag.Items = new SelectList(_itemRepository.GetAllItems(), "Id", "ItemName");
                return View(teacherEditViewModel);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TeacherEditViewModel model)
        {
            Teacher teacher = _teacherRepository.GetTeacherId(model.Id);

            teacher.Name = model.Name;
            teacher.Surname = model.Surname;
            teacher.Groups = model.Groups;
            teacher.ItemId = model.ItemId;
            teacher.Item = model.Item;

            if (model.Photo != null)
            {
                if (model.ExistingPhotoPath != null)
                {
                    string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                        "images", model.ExistingPhotoPath);
                    System.IO.File.Delete(filePath);
                }
                teacher.PhotoPath = ProcessUploadFile(model);
            }

            _teacherRepository.Update(teacher);
            return RedirectToAction("Index");
        }

        private string ProcessUploadFile(TeacherCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}

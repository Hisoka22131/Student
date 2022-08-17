using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StMagazine.Models;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using StMagazine.ViewModels;
using StMagazine.Interfaces;
using StMagazine.ViewModels.StViewModel;
using Microsoft.AspNetCore.Authorization;

namespace StMagazine.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "admin")]
    public class AdminStController : Controller
    {
        [Obsolete]
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IStudentRepository _studentRepository;
        private readonly IGroupRepository _groupRepository;

        
        public AdminStController(IStudentRepository studentRepository, IGroupRepository groupRepository,
            IHostingEnvironment hostingEnvironment)
        {
            _studentRepository = studentRepository;
            _groupRepository = groupRepository;
            this.hostingEnvironment = hostingEnvironment;
        }
        public ViewResult Index(string Name, int page = 1)
        {
            IEnumerable<Student> students = _studentRepository.GetAllStudents();
            IEnumerable<Group> groups = _groupRepository.GetAllGroups().ToList();
            if (!String.IsNullOrEmpty(Name))
                students = students.Where(n => (n.Name + " " + n.Surname).Contains(Name));
            int pageSize = 1;
            var count = students.Count();
            var skip = students.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            StudentViewModel svm = new StudentViewModel(skip, pageViewModel);
            return View(svm);
        }
        public IActionResult Create()
        {
            ViewBag.Groups = new SelectList(_groupRepository.GetAllGroups(), "Id", "GroupName");
            return View();
        }

        [HttpPost]
        [Obsolete]
        public async Task<IActionResult> Create(StudentCreateViewModel model)
        {
            string uniqueFileName = ProcessUploadFile(model);
            Student student = new Student
            {
                Name = model.Name,
                Surname = model.Surname,
                PhoneNumber = model.PhoneNumber,
                GroupId = model.GroupId,
                PhotoPath = uniqueFileName,
                Group = model.Group
            };
            _studentRepository.Add(student);
            return RedirectToAction("Index", new { Id = student.Id });
        }
        //DELETE
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (id != null)
            {
                Student student = _studentRepository.GetStudentId(id);
                StudentDeleteViewModel dvm = new StudentDeleteViewModel
                {
                    Id = student.Id,
                    Name = student.Name,
                    Surname = student.Surname,
                    Group = student.Group,
                    GroupId = student.GroupId,
                    ExistingPhotoPath = student.PhotoPath,
                    PhoneNumber = student.PhoneNumber
                };
                return View(dvm);
            };
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (id != null)
            {
                Student student = _studentRepository.GetStudentId(id);
                if (student != null)
                {
                    _studentRepository.Delete(id);
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
                Student student = _studentRepository.GetStudentId(id);
                StudentEditViewModel dvm = new StudentEditViewModel
                {
                    Id = student.Id,
                    Name = student.Name,
                    Surname = student.Surname,
                    PhoneNumber = student.PhoneNumber,
                    GroupId = student.GroupId,
                    Group = student.Group,
                    ExistingPhotoPath = student.PhotoPath
                };
                ViewBag.Groups = new SelectList(_groupRepository.GetAllGroups(), "Id", "GroupName");
                return View(dvm);
            }
            return NotFound();
        }
        [HttpPost]
        [Obsolete]
        public async Task<IActionResult> Edit(StudentEditViewModel model)
        {
            Student student = _studentRepository.GetStudentId(model.Id);

            student.Name = model.Name;
            student.Surname = model.Surname;
            student.GroupId = model.GroupId;
            student.Group = model.Group;
            student.PhoneNumber = model.PhoneNumber;

            if (model.Photo != null)
            {
                if (model.ExistingPhotoPath != null)
                {
                    string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                        "images", model.ExistingPhotoPath);
                    System.IO.File.Delete(filePath);
                }
                student.PhotoPath = ProcessUploadFile(model);
            }

            _studentRepository.Update(student);
            return RedirectToAction("Index");
        }
        [Obsolete]
        private string ProcessUploadFile(StudentCreateViewModel model)
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

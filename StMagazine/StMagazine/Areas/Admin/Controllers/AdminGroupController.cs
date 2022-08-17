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
using StMagazine.Interfaces;
using StMagazine.ViewModels.GVewModel;
using StMagazine.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace StMagazine.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "admin")]
    public class AdminGroupController : Controller
    {
        private readonly IGroupRepository _groupRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly ICoursRepository _coursRepository;
        public AdminGroupController(IGroupRepository groupRepository, ITeacherRepository teacherRepository,
            ICoursRepository coursRepository)
        {
            _groupRepository = groupRepository;
            _teacherRepository = teacherRepository;
            _coursRepository = coursRepository;
        }
        public ViewResult Index(string groupName, int page = 1)
        {
            IEnumerable<Group> groups = _groupRepository.GetAllGroups();
            IEnumerable<Teacher> teachers = _teacherRepository.GetAllTeacher().ToList();
            IEnumerable<Cours> cours = _coursRepository.GetAllCourses().ToList();
            if (!String.IsNullOrEmpty(groupName))
                groups = groups.Where(g => g.GroupName.Contains(groupName));

            int pageSize = 1;
            var count = groups.Count();
            var skip = groups.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            GroupViewModel gvm = new GroupViewModel(skip, pageViewModel);
            return View(gvm);
        }
        public IActionResult Create()
        {
            ViewBag.Courses = new SelectList(_coursRepository.GetAllCourses(), "Id", "CoursNumber");
            ViewBag.Teachers = new SelectList(_teacherRepository.GetAllTeacher(), "Id", "Name", "Surname");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(GroupCreateViewModel gvm)
        {

            Group group = new Group()
            {
                GroupName = gvm.Name,
                Year = gvm.Year,
                Speciality = gvm.Speciality,
                TeacherId = gvm.TeacherId,
                Teacher = gvm.Teacher,
                CoursId = gvm.CoursId,
                Cours = gvm.Cours,
                Students = gvm.Students
            };
            _groupRepository.Add(group);
            return RedirectToAction("Index", new { Id = group.Id });
        }
        //EDIT
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id != null)
            {
                Group group = _groupRepository.GetGroupId(id);
                GroupEditViewModel gvm = new GroupEditViewModel
                {
                    GroupId = group.Id,
                    Name = group.GroupName,
                    Year = group.Year,
                    Speciality = group.Speciality,
                    TeacherId = group.TeacherId,
                    Teacher = group.Teacher,
                    CoursId = group.CoursId,
                    Cours = group.Cours,
                    Students = group.Students
                };
                ViewBag.Courses = new SelectList(_coursRepository.GetAllCourses(), "CoursNumber", "CoursNumber");
                ViewBag.Teachers = new SelectList(_teacherRepository.GetAllTeacher(), "Surname", "Surname");
                return View(gvm);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(GroupEditViewModel gvm)
        {
            Group group = _groupRepository.GetGroupId(gvm.GroupId);

            group.GroupName = gvm.Name;
            group.Speciality = gvm.Speciality;
            group.Year = gvm.Year;
            group.Students = gvm.Students;
            group.Cours = gvm.Cours;
            group.CoursId = gvm.CoursId;
            group.Teacher = gvm.Teacher;
            group.TeacherId = gvm.TeacherId;
            _groupRepository.Update(group);
            return RedirectToAction("Index");
        }
        //DELETE
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (id != null)
            {
                Group group = _groupRepository.GetGroupId(id);
                GroupDeleteViewModel gvm = new GroupDeleteViewModel
                {
                    Id = group.Id,
                    Name = group.GroupName,
                    Year = group.Year,
                    Speciality = group.Speciality,
                    TeacherId = group.TeacherId,
                    Teacher = group.Teacher,
                    CoursId = group.CoursId,
                    Cours = group.Cours,
                    Students = group.Students
                };
                return View(gvm);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (id != null)
            {
                Group group = _groupRepository.GetGroupId(id);
                if (group != null)
                {
                    _groupRepository.Delete(id);
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}

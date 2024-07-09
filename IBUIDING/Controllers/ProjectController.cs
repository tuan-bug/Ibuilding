using IBUIDING.Models;
using IBUIDING.Models.DTO;
using IBUIDING.Service;
using IBUIDING.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IBUIDING.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProjectController(ApplicationDbContext context)
        {
            this._context = context;
        }
        public ActionResult Index()
        {
            var projects = _context.Projects.Select(p => new Project
            {
                Id = p.Id,
                CodeProject = p.CodeProject,
                NameProject = p.NameProject,
                PeopleContact = p.PeopleContact,
                PhoneContact = p.PhoneContact ?? "", // Kiểm tra và gán mặc định khi null
                AddressProject = p.AddressProject,
                Description = p.Description ?? "" // Kiểm tra và gán mặc định khi null
            }).ToList();

            // Kiểm tra nếu không có dự án nào trong cơ sở dữ liệu
            if (projects.Count == 0)
            {
                return View(new List<Project>()); // Trả về view với danh sách rỗng
            }

            ViewBag.DisplayIndex = 1;
            return View(projects);
        }



        public ActionResult CreateProject()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(ProjectDTO projectDTO)
        {
            var Id = GenerateNewId.Id(36);
            
            if (projectDTO.CodeProject == null || projectDTO.NameProject == null || projectDTO.AddressProject == null)
            {
                return View(projectDTO);
            }

            Project project = new Project()
            {
                Id = Id,
                CodeProject = projectDTO.CodeProject,
                NameProject = projectDTO.NameProject,
                AddressProject = projectDTO.AddressProject,
                PeopleContact = projectDTO.PeopleContact,
                PhoneContact = projectDTO.PhoneContact,
                Description = projectDTO.Description,
            };
            _context.Projects.Add(project);
            _context.SaveChangesAsync();
            return RedirectToAction("Index", "project");
        }

        public IActionResult EditProject(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = _context.Projects
                .Where(p => p.Id == id) // Lọc theo Id
                .Select(p => new ProjectDTO
                { 
                    Id = p.Id,
                    CodeProject = p.CodeProject ?? "",
                    NameProject = p.NameProject ?? "",
                    PeopleContact = p.PeopleContact ?? "",
                    PhoneContact = p.PhoneContact ?? "",
                    AddressProject = p.AddressProject ?? "",
                    Description = p.Description ?? ""
                    // Các thuộc tính khác của ProjectDTO
                })
                .FirstOrDefault();

            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProject(string id, Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }


    }
}

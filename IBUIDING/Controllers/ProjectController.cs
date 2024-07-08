using IBUIDING.Models;
using IBUIDING.Service;
using Microsoft.AspNetCore.Mvc;

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
            var projects = GenerateSampleProjects();
            return View(projects);
        }

        private List<Project> GenerateSampleProjects()
        {
            return new List<Project>
            {
                new Project { Id = "1", CodeProject = "CP001", NameProject = "Project One", PhoneContact = "1234567890", AddressProject = "123 Street, City, Country" },
                new Project { Id = "2", CodeProject = "CP002", NameProject = "Project Two", PhoneContact = "0987654321", AddressProject = "456 Avenue, City, Country" },
                new Project { Id = "3", CodeProject = "CP003", NameProject = "Project Three", PhoneContact = "1122334455", AddressProject = "789 Boulevard, City, Country" },
                new Project { Id = "4", CodeProject = "CP004", NameProject = "Project Four", PhoneContact = "6677889900", AddressProject = "101 Circle, City, Country" },
                new Project { Id = "5", CodeProject = "CP005", NameProject = "Project Five", PhoneContact = "2233445566", AddressProject = "202 Square, City, Country" }
            };
        }
    }
}

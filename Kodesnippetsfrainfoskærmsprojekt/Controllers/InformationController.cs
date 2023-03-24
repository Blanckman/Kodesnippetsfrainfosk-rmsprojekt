using InformationScreen.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using InformationScreen.Models;
using InformationScreen.Web.Models.ViewModels;

namespace InformationScreen.Web.Controllers {
    public class InformationController : Controller {

        private IInfoRepository repo;

        public InformationController(IInfoRepository repository) {
            repo = repository;
        }
        public IActionResult Index() {
            return View();
        }

        public ViewResult InformationHandling(string? DeptName, string? InfoName) {
            return View(GetInfosByName(DeptName, InfoName));
        }

        [HttpPost]
        public ViewResult InformationHandling(InformationHandlingViewModel i, string? DeptName, string? InfoName) { 
            if (ModelState.IsValid) {
                repo.CreateInformation(i.information);
                return View(GetInfosByName(DeptName, InfoName));
            }
            return View(GetInfosByName(DeptName, InfoName));
        }

        public IActionResult ToggleActive(int InfoId) {
            repo.ToggleActive(InfoId);
            return RedirectToAction("InformationHandling");
        }

        public IActionResult DeleteInfo(int InfoId) {
            repo.DeleteInfo(InfoId);
            return RedirectToAction("InformationHandling");
        }

        // Choose infor Screen and Information Screen Controls
        public ViewResult ChooseInfoScreen(int departmentId) {
            return View(new ChooseInfoScreenViewModel {
                Departments = repo.Departments.Where(d => departmentId == 0 || d.DepartmentId == departmentId).OrderBy(d => d.DepartmentName),
                CurrentDepartmentId = departmentId
            }); 
        }

        public ViewResult InformationScreen(ChooseInfoScreenViewModel viewModel, int departmentId) {
            return View(GetEventsAndRooms(departmentId));
        }

        /* --------------- *
         * Service Methods *
         * --------------- */
        public InformationHandlingViewModel GetInfosByName(string DeptName, string InfoName) {
            return new InformationHandlingViewModel {
                Departments = repo.Departments.Where(dept => DeptName == null || dept.DepartmentName == DeptName).OrderBy(dept => dept.DepartmentName),
                CurrentDepartment = DeptName,
                Informations = repo.Informations.Where(info => InfoName == null || info.Topic == InfoName).OrderBy(info => info.Topic),
                CurrentInfo = InfoName
            };
        }

        public ChooseInfoScreenViewModel GetEventsAndRooms(int departmentId) {
            return new ChooseInfoScreenViewModel {
                Rooms = repo.Rooms.Where(r => departmentId == 0 || r.DepartmentId == departmentId).OrderBy(r=> r.RoomName),
                Events = repo.Events.OrderBy(e => e.FromDate),
                Informations = repo.Informations.Where(i => departmentId == 0 || i.DepartmentId == departmentId).OrderBy(i => i.DepartmentId),
                Departments = repo.Departments.OrderBy(d => d.DepartmentId)
            };
        }
    }
}
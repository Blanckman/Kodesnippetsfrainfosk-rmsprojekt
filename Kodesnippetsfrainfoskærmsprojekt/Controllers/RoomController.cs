using InformationScreen.Models;
using InformationScreen.Web.Models;
using InformationScreen.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace InformationScreen.Web.Controllers
{
    public class RoomController : Controller {
        private IInfoRepository repo;

        public RoomController(IInfoRepository repository) {
            repo = repository;
        }

        // Create Room
        [HttpPost]
        public ViewResult CreateRoom(string? departmentName, RoomViewModel viewModel) {
            if (ModelState.IsValid) {
                repo.CreateRoom(viewModel.Room);
                return View("RoomOverview", repo.Rooms.Include(r => r.Department).OrderBy(r=> r.RoomName));
            } else {
                viewModel = GetDepartmentByName(departmentName);

                return View(viewModel);
            }
        }

        public ViewResult CreateRoom(string? departmentName) {
            return View(GetDepartmentByName(departmentName));
        }

        // Read (view Rooms)
        public ViewResult RoomOverview() {
            var rooms = repo.Rooms.Include(r => r.Department).OrderBy(r=> r.RoomName);
            return View(rooms);
        }

        // Update Room
        public ViewResult UpdateRoom(int roomId) =>
           View(repo.Rooms
               .FirstOrDefault(r => r.RoomId == roomId));

        [HttpPost]
        public IActionResult UpdateRoom(Room room) {
            if (ModelState.IsValid) {
                repo.UpdateRoom(room);
                return RedirectToAction("RoomOverview");
            } else
                return RedirectToAction("RoomOverview");
        }

        // Delete Room
        [HttpPost]
        public IActionResult DeleteRoom(int roomId) {
            Room deletedRoom = repo.DeleteRoom(roomId);
            if (deletedRoom != null) {
                TempData["message"] = $"{deletedRoom.RoomName} er slettet";
            }
            return RedirectToAction("RoomOverview");
        }

        public RoomViewModel GetDepartmentByName(string? departmentName) {
            return new RoomViewModel {
                Departments = repo.Departments.Where(r => departmentName == null || r.DepartmentName == departmentName).OrderBy(r => r.DepartmentName),
                CurrentDepartmentName = departmentName
            };

        }
    }
}

using InformationScreen.Models;

namespace InformationScreen.Web.Models.ViewModels
{
    public class RoomViewModel
    {
        public Room Room { get; set; } = new();

        public IEnumerable<Department> Departments { get; set; } = Enumerable.Empty<Department>();

        public IEnumerable<Room> Rooms { get; set; } = Enumerable.Empty<Room>();

        public string? CurrentDepartmentName { get; set; }
    }
}

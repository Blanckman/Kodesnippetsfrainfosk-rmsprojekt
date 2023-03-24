using InformationScreen.Models;

namespace InformationScreen.Web.Models.ViewModels {
    public class ChooseInfoScreenViewModel {

        public IEnumerable<Department> Departments { get; set; } = Enumerable.Empty<Department>();

        public IEnumerable<Event> Events { get; set; } = Enumerable.Empty<Event>();
       
        public IEnumerable<Room> Rooms { get; set; } = Enumerable.Empty<Room>();

        public IEnumerable<Information> Informations { get; set; } = Enumerable.Empty<Information>();

        public Information? Information { get; set; } = new Information();

        public int CurrentDepartmentId { get; set; }

    }
}

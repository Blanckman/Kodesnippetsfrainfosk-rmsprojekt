using InformationScreen.Models;

namespace InformationScreen.Web.Models {
    public interface IInfoRepository {



        IEnumerable<Department> Departments { get; }

        //Update
        void UpdateDepartment(Department department);

        //Delete
        Department DeleteDepartment(int DepartmentId);


        IQueryable<Event> Events { get; }
        IQueryable<Information> Informations { get; }
        IQueryable<Room> Rooms { get; }

        void CreateRoom(Room room);
        void UpdateRoom(Room room);
        Room DeleteRoom(int roomId);

        void CreateEvent(Event e);
        void UpdateEvent(Event e);
        void DeleteEvent(int eventId);

        void CreateInformation(Information info);

        void ToggleActive(int InfoId);
        void DeleteInfo(int InfoId);


    }

  

}

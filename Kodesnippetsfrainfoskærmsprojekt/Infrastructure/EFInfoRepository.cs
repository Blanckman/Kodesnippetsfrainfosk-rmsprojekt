using InformationScreen.Models;
using InformationScreen.Web.Models;

namespace InformationScreen.Web.Infrastructure
{
    public class EFInfoRepository : IInfoRepository
    {
        private InfoDbContext context;

        public EFInfoRepository(InfoDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Department> Departments => context.Departments;

        //Create & Update
        public void UpdateDepartment(Department department)
        {
            if (department.DepartmentId == 0)
            {
                context.Departments.Add(department);
            }
            else
            {
                Department dbEntry = context.Departments.FirstOrDefault(d => d.DepartmentId == department.DepartmentId);
                if (dbEntry != null)
                {
                    dbEntry.DepartmentName = department.DepartmentName;
                }
            }
            context.SaveChanges();
        }

        //Delete
        public Department DeleteDepartment(int DepartmentId)
        {
            Department dbEntry = context.Departments.FirstOrDefault(d => d.DepartmentId == DepartmentId);
            if (dbEntry != null)
            {
                context.Departments.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public IQueryable<Event> Events => context.Events;

        public IQueryable<Information> Informations => context.Informations;

        public IQueryable<Room> Rooms => context.Rooms;

        // CRUD on Rooms
        public void CreateRoom(Room room)
        {
            context.Rooms.Add(room);
            context.SaveChanges();
        }

        public void UpdateRoom(Room room)
        {
            Room dbEntry = context.Rooms
                     .FirstOrDefault(r => r.RoomId == room.RoomId);
            if (dbEntry != null)
            {
                dbEntry.RoomName = room.RoomName;
            }
            context.SaveChanges();
        }

        public Room DeleteRoom(int roomId)
        {
            Room dbEntry = context.Rooms
              .FirstOrDefault(r => r.RoomId == roomId);
            if (dbEntry != null)
            {
                context.Rooms.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void CreateEvent(Event e)
        {
            context.Events.Add(e);
            context.SaveChanges();
        }

        public void UpdateEvent(Event e)
        {
            if (e.EventId == 0)
            {
                context.Events.Add(e);
            }
            else
            {
                Event dbEntry = context.Events.FirstOrDefault(ev => ev.EventId == e.EventId);
                if (dbEntry != null)
                {
                    dbEntry.IsCanceled = e.IsCanceled;
                }
            }
            context.SaveChanges();
        }

        public void DeleteEvent(int eventId)
        {
            Event dbEntry = context.Events.FirstOrDefault(e => e.EventId == eventId);
            if (dbEntry != null)
            {
                context.Events.Remove(dbEntry);
                context.SaveChanges();
            }
        }


        public void CreateInformation(Information info)
        {
            info.IsActive = true;
            context.Informations.Add(info);
            context.SaveChanges();
        }
        public void ToggleActive(int InfoId)
        {
            Information dbEntry = context.Informations.FirstOrDefault(i => i.InformationId == InfoId);
            if (dbEntry != null)
            {
                dbEntry.IsActive = !dbEntry.IsActive;
            }
            context.SaveChanges();
        }

        public void DeleteInfo(int InfoId)
        {
            Information dbEntry = context.Informations.FirstOrDefault(i => i.InformationId == InfoId);
            if (dbEntry != null)
            {
                context.Informations.Remove(dbEntry);
                context.SaveChanges();
            }
        }
    }
}

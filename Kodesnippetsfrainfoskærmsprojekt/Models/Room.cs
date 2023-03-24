using System.ComponentModel.DataAnnotations;

namespace InformationScreen.Models {
    public class Room {
        public int RoomId { get; set; }
        
        [Required(ErrorMessage = "Indtast navnet på lokalet")]
        public string? RoomName { get; set; }

        [Required(ErrorMessage = "Vælg afdeling")]
        public int DepartmentId { get; set; }

       
        public Department? Department { get; set; }
    }
}
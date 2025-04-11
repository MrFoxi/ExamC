using System.ComponentModel.DataAnnotations;

namespace MaintenanceApi.Models
{
    public class Technician
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? UserId { get; set; } // Id venant de AspNetUsers
    }
}
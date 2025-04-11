using System.ComponentModel.DataAnnotations;

namespace MaintenanceApi.Models
{
    public class InterventionTechnician
    {
        public int InterventionId { get; set; }
        public Intervention Intervention { get; set; } = null!;

        

        public int TechnicianId { get; set; }
        public Technician Technician { get; set; } = null!;

        [Required]
        public DateTime Date { get; set; }
    }
}

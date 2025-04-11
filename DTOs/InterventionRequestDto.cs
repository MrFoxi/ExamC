using System.ComponentModel.DataAnnotations;

namespace MaintenanceApi.DTOs
{
    public class InterventionRequestDto
    {
        [Required]
        public string Type { get; set; } = string.Empty;

        [Required]
        public int ClientId { get; set; }

        [Required]
        public List<int> TechnicianIds { get; set; } = new();

        [Required]
        public DateTime Date { get; set; }
    }
}

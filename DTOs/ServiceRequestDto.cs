using System.ComponentModel.DataAnnotations;

namespace MaintenanceApi.DTOs
{
    public class ServiceRequestDto
    {
        [Required]
        public string Type { get; set; } = string.Empty;
    }
}

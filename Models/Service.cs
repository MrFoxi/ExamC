using System;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceApi.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; } = string.Empty;
    }
}

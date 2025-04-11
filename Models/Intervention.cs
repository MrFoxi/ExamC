using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaintenanceApi.Models
{
    public class Intervention
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; } = string.Empty;

        public DateTime Date { get; set; }
        // Client
        [Required]
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; } = null!;

        // Techniciens (relation many-to-many via table de jointure)
        public ICollection<InterventionTechnician> InterventionTechnicians { get; set; } = new List<InterventionTechnician>();
    }
}

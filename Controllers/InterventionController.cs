using MaintenanceApi.Data;
using MaintenanceApi.DTOs;
using MaintenanceApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaintenanceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterventionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InterventionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateIntervention(InterventionRequestDto dto)
        {
            var client = _context.Clients.Find(dto.ClientId);
            if (client == null)
                return NotFound(new { message = "Client not found" });

            var technicians = _context.Technicians
                .Where(t => dto.TechnicianIds.Contains(t.Id))
                .ToList();

            if (technicians.Count != dto.TechnicianIds.Count)
                return BadRequest(new { message = "One or more technicians not found" });

            if (dto.Date < DateTime.Now)
                throw new ArgumentException("La date ne peut pas être dans le passé.");

            var intervention = new Intervention
            {
                Type = dto.Type,
                ClientId = dto.ClientId,
                InterventionTechnicians = technicians.Select(t => new InterventionTechnician
                {
                    TechnicianId = t.Id
                }).ToList()
            };

            _context.Interventions.Add(intervention);
            _context.SaveChanges();

            return Ok(new
            {
                intervention.Id,
                intervention.Type,
                intervention.ClientId,
                Technicians = technicians.Select(t => new
                {
                    t.Id,
                    t.Name
                })
            });
        }

        [HttpGet("mine")]
        [Authorize(Roles = "Technicien")]
        public IActionResult GetMyInterventions()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var technician = _context.Technicians
                .FirstOrDefault(t => t.UserId == userId);

            if (technician == null)
                return NotFound(new { message = "Technician not found" });

            var interventions = _context.Interventions
                .Include(i => i.InterventionTechnicians)
                .ThenInclude(it => it.Technician)
                .Where(i => i.InterventionTechnicians.Any(it => it.TechnicianId == technician.Id))
                .Select(i => new
                {
                    i.Id,
                    i.Type,
                    i.ClientId,
                    Technicians = i.InterventionTechnicians.Select(it => new
                    {
                        it.Technician.Id,
                        it.Technician.Name
                    })
                })
                .ToList();

            return Ok(interventions);
        }
    }
}

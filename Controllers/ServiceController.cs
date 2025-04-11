using MaintenanceApi.Data;
using MaintenanceApi.DTOs;
using MaintenanceApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MaintenanceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServiceController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateService(ServiceRequestDto dto)
        {
            var service = new Service
            {
                Type = dto.Type
            };

            _context.Services.Add(service);
            _context.SaveChanges();

            return Ok(service);
        }
    }
}

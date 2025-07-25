using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AppointmentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> BookAppointment([FromBody] Appointment appointment)
        {
            var slot = await _context.Slots.FirstOrDefaultAsync(s =>
                s.SlotDateTime == appointment.SlotDateTime && !s.IsBooked);

            if (slot == null)
                return BadRequest("Slot not available or already booked.");

            slot.IsBooked = true;
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            return Ok(appointment);
        }

        [HttpGet("client/{email}")]
        public async Task<IActionResult> GetAppointmentsForClient(string email)
        {
            var appointments = await _context.Appointments
                .Where(a => a.Email == email)
                .ToListAsync();
            return Ok(appointments);
        }

        [HttpGet("admin")]
        public async Task<IActionResult> GetAllAppointments()
        {
            return Ok(await _context.Appointments.ToListAsync());
        }

        [HttpDelete("admin/{id}")]
        public async Task<IActionResult> CancelAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null) return NotFound();

            var slot = await _context.Slots.FirstOrDefaultAsync(s => s.SlotDateTime == appointment.SlotDateTime);
            if (slot != null) slot.IsBooked = false;

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}

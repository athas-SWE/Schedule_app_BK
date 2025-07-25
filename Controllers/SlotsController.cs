using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SlotsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SlotsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableSlots()
        {
            var slots = await _context.Slots
                //.Where(s => !s.IsBooked && s.SlotDateTime > DateTime.Now)
                .ToListAsync();
            return Ok(slots);
        }


        [HttpPost]
        public async Task<IActionResult> CreateSlot([FromBody] Slot slot)
        {
            _context.Slots.Add(slot);
            await _context.SaveChangesAsync();
            return Ok(slot);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlot(int id)
        {
            var slot = await _context.Slots.FindAsync(id);
            if (slot == null) return NotFound();
            _context.Slots.Remove(slot);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}

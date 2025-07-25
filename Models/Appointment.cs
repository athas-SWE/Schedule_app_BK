namespace Api.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime SlotDateTime { get; set; }
        public string? Notes { get; set; }
    }
}

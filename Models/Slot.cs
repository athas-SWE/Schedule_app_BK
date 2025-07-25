namespace Api.Models
{
    public class Slot
    {
        public int Id { get; set; }
        public DateTime SlotDateTime { get; set; }
        public bool IsBooked { get; set; } = false;
    }

}

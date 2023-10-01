namespace CampusStay.Web.Models.Domain
{
    public class Campus
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int FreeRoomNumbers { get; set; }
        public virtual ICollection<DormRoom> DormRooms { get; set; }
    }
}

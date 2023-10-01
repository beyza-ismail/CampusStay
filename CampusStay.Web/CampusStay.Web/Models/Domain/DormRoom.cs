using System.ComponentModel.DataAnnotations;

namespace CampusStay.Web.Models.Domain
{
    public class DormRoom
    {
        public Guid Id { get; set; }
        [Required]
        public string RoomName { get; set; }
        [Required]
        public string RoomImage { get; set; }
        [Required]
        public string RoomDescription { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Rating { get; set; }

        public Guid CampusId { get; set; }
        public virtual Campus Campus { get; set; }
        public virtual ICollection<DormRoomInShoppingCart> DormRoomInShoppingCarts { get; set; }
    }
}

using CampusStay.Web.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace CampusStay.Web.Models.Domain
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public virtual ICollection<DormRoomInShoppingCart> DormRoomInShoppingCarts { get; set; }
    }
}

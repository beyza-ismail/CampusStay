namespace CampusStay.Web.Models.Domain
{
    public class DormRoomInShoppingCart
    {
        public Guid DormRoomId { get; set; }
        public DormRoom DormRoom { get; set; }
        public Guid ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}

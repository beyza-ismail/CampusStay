using CampusStay.Web.Models.Domain;
using Microsoft.AspNetCore.Identity;

namespace CampusStay.Web.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; } 

    }
}

using Microsoft.AspNetCore.Identity;

namespace TShop.Models
{
    public class TShopUser :IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}

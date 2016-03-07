using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KYC.Web.Models.Identity
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public List<UserAddress> Addresses { get; set; }
    }
}

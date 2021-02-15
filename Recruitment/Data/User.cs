using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.Data
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<IdentityUserRole<int>> Roles { get; set; } = new List<IdentityUserRole<int>>();

        public virtual ICollection<IdentityUserClaim<int>> Claims { get; set; } = new List<IdentityUserClaim<int>>();

    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.Data
{
    public class Role : IdentityRole<int>
    {
        public virtual ICollection<IdentityUserRole<int>> Users { get; set; } = new List<IdentityUserRole<int>>();

        ///// <summary>
        ///// Navigation property for claims in this role.
        ///// </summary>  
        public virtual ICollection<IdentityRoleClaim<int>> Claims { get; set; } = new List<IdentityRoleClaim<int>>();

    }
}

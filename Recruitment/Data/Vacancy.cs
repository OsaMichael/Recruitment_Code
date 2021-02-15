using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.Data
{
    public class Vacancy : BaseEntity.Entity
    {
       
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }

        public virtual ICollection<Application> Application { get; set; }
    }
}

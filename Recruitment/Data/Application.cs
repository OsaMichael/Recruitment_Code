using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.Data
{
    public class Application : BaseEntity.Entity
    {

        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
        public int JobId { get; set; }
        public Vacancy Vacancy { get; set; }
    }
}

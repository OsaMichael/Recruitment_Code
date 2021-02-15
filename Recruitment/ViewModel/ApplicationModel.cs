using Recruitment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.ViewModel
{
    public class ApplicationModel
    {
        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
        public int JobId { get; set; }
        public Vacancy Vacancy { get; set; }
    }
}

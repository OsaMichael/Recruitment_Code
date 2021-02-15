using Recruitment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.Repository
{
    public interface IApplicantRepository
    {
        Task<(bool IsCreated, string Message)> AddApplicant(Applicant applicant);
    }
}

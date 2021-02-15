using Recruitment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.Repository.ApplicationRepo
{
    public interface IApplicationRepository
    {
        Task<(bool IsCreated, string Message)> VacancyApplication(Application vacancy);
    }
}

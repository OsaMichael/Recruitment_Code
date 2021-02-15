using Recruitment.Data;
using Recruitment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.Repository.VacancyRepo
{
    public interface IVacancyRepository
    {
        Task<(bool IsCreated, string Message)> AddVacancy(Vacancy vacancy);
        Task<(bool IsUpdated, string Message)> UpdateVacancy(VacancyModel model);
    }
}

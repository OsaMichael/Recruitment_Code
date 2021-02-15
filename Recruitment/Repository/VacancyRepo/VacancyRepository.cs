using Recruitment.Data;
using Recruitment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.Repository.VacancyRepo
{
    public class VacancyRepository : IVacancyRepository
    {
        private readonly DataContext _context;

        public VacancyRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<(bool IsCreated, string Message)> AddVacancy(Vacancy vacancy)
        {
            if (vacancy == null) throw new Exception("form should not be empty");

            var existed = _context.Vacancies.Where(x => x.Id == vacancy.Id ).FirstOrDefault();
            if (existed != null) throw new Exception("same vancancy cannt be duplicated");

            else
            {
                Vacancy newVacancy = new Vacancy
                {
                     JobTitle = vacancy.JobTitle,
                      JobDescription = vacancy.JobDescription,
                       //DateCreated = vacancy.DateCreated,
                      IsActive = true,
                };

                await _context.Vacancies.AddAsync(newVacancy);

            }
            await _context.SaveChangesAsync();
            return (true, "vancancy has been created successfully");

        }
        public async Task<(bool IsUpdated, string Message)> UpdateVacancy(VacancyModel model)
        {
            var update = _context.Vacancies.Where(x => x.Id == model.Id).FirstOrDefault();
            if (update != null)
            {
                update.JobTitle = model.JobTitle;
                update.JobDescription = model.JobDescription;
                _context.Vacancies.Update(update);
                await _context.SaveChangesAsync();
            }
            else
            {
                return (false, "vacancy not found");
            }
            return (true, "Updated Successfully");
        }
    }
}

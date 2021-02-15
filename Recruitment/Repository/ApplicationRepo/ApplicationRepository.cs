using Recruitment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.Repository.ApplicationRepo
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly DataContext _context;

        public ApplicationRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<(bool IsCreated, string Message)> VacancyApplication(Application vacancy)
        {
            if (vacancy == null) throw new Exception("form should not be empty");

            var existed = _context.Applications.Where(x => x.ApplicantId == vacancy.ApplicantId && x.JobId == vacancy.JobId).FirstOrDefault();
            if (existed != null) throw new Exception("you cannot apply twice");

            else
            {
                Application newApplication = new Application
                {
                     ApplicantId = vacancy.ApplicantId,
                      JobId = vacancy.JobId
                };

                await _context.Applications.AddAsync(newApplication);

            }
            await _context.SaveChangesAsync();
            return (true, "application was successful");

        }
    }
}

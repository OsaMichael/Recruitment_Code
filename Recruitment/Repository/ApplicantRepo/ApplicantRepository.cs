using Recruitment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.Repository.ApplicantRepo
{
    public class ApplicantRepository: IApplicantRepository
    {
        
        private readonly DataContext _context;

        public ApplicantRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<(bool IsCreated, string Message)> AddApplicant(Applicant applicant)
        {
            if (applicant == null) throw new Exception("form should not be empty");

            var existed = _context.Applicants.Where(x => x.Id == applicant.Id && x.Email == applicant.Email).FirstOrDefault();
            if (existed != null) throw new Exception("applicant with email already exist");

            else
            {
                Applicant applicantNew = new Applicant
                {
                    Email = applicant.Email,              
                    Mobile = applicant.Mobile,
                    Name = applicant.Name,
                    Sex = applicant.Sex,
                    IsActive = true,
                };

                await _context.Applicants.AddAsync(applicantNew);

            }
            await _context.SaveChangesAsync();
            return (true, "applicant has been created successfully");

        }
    }
}

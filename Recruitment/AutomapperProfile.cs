using AutoMapper;
using Recruitment.Data;
using Recruitment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<ApplicationModel, Application>().ReverseMap();
            CreateMap<VacancyModel, Vacancy>().ReverseMap();
            CreateMap<ApplicantModel, Applicant>().ReverseMap();

        }

    }
}

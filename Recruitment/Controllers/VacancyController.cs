using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruitment.Data;
using Recruitment.Repository.VacancyRepo;
using Recruitment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly IVacancyRepository _repo;
        private readonly IMapper _mapper;
        public VacancyController(IVacancyRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        [HttpPost("addNew")]
        public async Task<IActionResult> AddVacancy(VacancyModel model)
        {
            if (ModelState.IsValid)
            {
                var vacancy = _mapper.Map<Vacancy>(model);
                var vacNew = await _repo.AddVacancy(vacancy);
                if (vacNew.IsCreated)
                {
                    return Ok("success");
                }
                else
                {
                    return BadRequest("error");
                }
            }
            return BadRequest("bad");
        }

        [HttpPost("modify")]
        public async Task<IActionResult> Update([FromBody] VacancyModel model)
        {
            if (ModelState.IsValid)
            {
                var vacancy = await _repo.UpdateVacancy(model);
                if (vacancy.IsUpdated)
                {
                    return Ok("success");
                }
                else
                {
                    return BadRequest("error");
                }
            }
            return BadRequest("bad");
        }
    }
}

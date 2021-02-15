using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruitment.Data;
using Recruitment.Repository.ApplicationRepo;
using Recruitment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationRepository _repo;
        private readonly IMapper _mapper;

        public ApplicationController(IApplicationRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPost("apply")]
        public async Task<IActionResult> Application(VacancyModel model)
        {
            if (ModelState.IsValid)
            {
                var vacancy = _mapper.Map<Application>(model);
                var vacNew = await _repo.VacancyApplication(vacancy);
                if (vacNew.IsCreated)
                {
                    return Ok("success");
                }
                else
                {
                    return BadRequest("user cannot apply twice");
                }
            }
            return BadRequest("bad");
        }
    }
}

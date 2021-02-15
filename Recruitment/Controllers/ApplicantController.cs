using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruitment.Data;
using Recruitment.Repository;
using Recruitment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantRepository _repo;
        private readonly IMapper _mapper;

        public ApplicantController(IApplicantRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPost("new")]
        public async Task<IActionResult> Add([FromBody] ApplicantModel model)
        {
            if (ModelState.IsValid)
            {
                var applicant = _mapper.Map<Applicant>(model);
                var app = await _repo.AddApplicant(applicant);
                if (app.IsCreated)
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

using HospitalApi.Application.Features.DoctorChecks.Command.CreateDoctorCheckCommand;
using HospitalApi.Application.Features.DoctorChecks.Command.DeleteDoctorCheck;
using HospitalApi.Application.Features.DoctorChecks.Command.UpdateDoctorCheck;
using HospitalApi.Application.Features.DoctorChecks.Queries.GetAllDoctorChecks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize(Roles = "doctor,secretary")]
    public class DoctorCheckController : ControllerBase
    {
        private readonly IMediator mediator;
        public DoctorCheckController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctorCheck()
        {
            var response = await mediator.Send(new GetAllDoctorChecksQueryRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctorCheck(CreateDoctorCheckCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDoctorCheck(UpdateDoctorCheckCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost]     
        public async Task<IActionResult> DeleteDoctorCheck(DeleteDoctorCheckCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}

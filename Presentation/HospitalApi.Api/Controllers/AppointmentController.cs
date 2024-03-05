using HospitalApi.Application.Features.Appointments.Queries.GetAllAppointments;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator mediator;
        public AppointmentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var response = await mediator.Send(new GetAllAppointmentsQueryRequest());
            return Ok(response);
        }
    }
}

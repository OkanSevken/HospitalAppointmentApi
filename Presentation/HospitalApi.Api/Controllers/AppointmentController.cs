﻿using HospitalApi.Application.Features.Appointments.Command.CreateAppointment;
using HospitalApi.Application.Features.Appointments.Command.DeleteAppointment;
using HospitalApi.Application.Features.Appointments.Command.UpdateAppointment;
using HospitalApi.Application.Features.Appointments.Queries.GetAllAppointments;
using HospitalApi.Application.Features.Appointments.Queries.GetByIdAppointments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        //[Authorize(Roles ="doctor,secretary")]
        public async Task<IActionResult> GetAllAppointments()
        {
            var response = await mediator.Send(new GetAllAppointmentsQueryRequest());
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetByIdAppointments(int id)
        {          
            var response = await mediator.Send(new GetByIdAppointmentsQueryRequest(id));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointments(CreateAppointmentCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost]
       
        public async Task<IActionResult> UpdateAppointments(UpdateAppointmentCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        //[Authorize(Roles = "doctor,secretary")]
        public async Task<IActionResult> DeleteAppointments(DeleteAppointmentCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}

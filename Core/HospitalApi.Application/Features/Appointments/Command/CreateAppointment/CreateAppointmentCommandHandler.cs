using HospitalApi.Application.Interfaces.AutoMapper;
using HospitalApi.Application.Interfaces.UnitOfWorks;
using HospitalApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Features.Appointments.Command.CreateAppointment
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommandRequest,Unit>
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CreateAppointmentCommandHandler(UserManager<User> userManager,IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<Unit> Handle(CreateAppointmentCommandRequest request, CancellationToken cancellationToken)
        {
            
            Appointment appointment = new(request.PatientId, request.AppointmentDate, request.DoctorId , request.Description,request.AppointmentTime);
            
            await unitOfWork.GetWriteRepository<Appointment>().AddAsync(appointment);

            var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);  // Login yapan kullanıcının bilgilerini çektim

            appointment.CreaterUserId = 15;

            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}

using HospitalApi.Application.Interfaces.AutoMapper;
using HospitalApi.Application.Interfaces.UnitOfWorks;
using HospitalApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Features.Appointments.Command.DeleteAppointment
{
    public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommandRequest, Unit>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;

        public DeleteAppointmentCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) 
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<Unit> Handle(DeleteAppointmentCommandRequest request, CancellationToken cancellationToken)
        {
            var appointment= await unitOfWork.GetReadRepository<Appointment>().GetAsync(x=> x.Id ==request.Id && !x.IsDeleted);

            appointment.IsDeleted = true;

            appointment.LastModifyDate = DateTime.Now;

            appointment.LastUserId  = request.UserId;

            await unitOfWork.GetWriteRepository<Appointment>().UpdateAsync(appointment);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}

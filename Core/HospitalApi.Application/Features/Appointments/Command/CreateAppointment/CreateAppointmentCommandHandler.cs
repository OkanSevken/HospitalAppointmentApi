using HospitalApi.Application.Interfaces.UnitOfWorks;
using HospitalApi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Features.Appointments.Command.CreateAppointment
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommandRequest,Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateAppointmentCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateAppointmentCommandRequest request, CancellationToken cancellationToken)
        {
            
            Appointment appointment = new(request.PatientId, request.AppointmentDate, request.DoctorId , request.Description,request.AppointmentTime);
            
            await unitOfWork.GetWriteRepository<Appointment>().AddAsync(appointment);
            
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}

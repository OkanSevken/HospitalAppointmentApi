using HospitalApi.Application.Interfaces.UnitOfWorks;
using HospitalApi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Features.Appointments.Queries.GetByIdAppointments
{
    public class GetByIdAppointmentsQueryHandler : IRequestHandler<GetByIdAppointmentsQueryRequest, GetByIdAppointmentsQueryResponse>
    {

        private readonly IUnitOfWork unitOfWork;


        public GetByIdAppointmentsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<GetByIdAppointmentsQueryResponse> Handle(GetByIdAppointmentsQueryRequest request, CancellationToken cancellationToken)
        {
            var appointments = await unitOfWork.GetReadRepository<Appointment>().GetAsync(x => x.Id == request.Id);

            if (appointments != null)
            {
                return new GetByIdAppointmentsQueryResponse
                {
                    AppointmentDate = appointments.AppointmentDate,
                    AppointmentTime = appointments.AppointmentTime,
                    PatientId = appointments.PatientId,
                    DoctorId = appointments.DoctorId,
                    IsApproved = appointments.IsApproved,
                    Description = appointments.Description
                };
            }

            else
            {            
                throw new Exception("Belirtilen id ile eşleşen bir randevu bulunamadı.");
            }

        }
    }
}

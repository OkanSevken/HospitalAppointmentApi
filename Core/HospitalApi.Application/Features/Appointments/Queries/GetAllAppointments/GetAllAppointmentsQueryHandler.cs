using HospitalApi.Application.Interfaces.AutoMapper;
using HospitalApi.Application.Interfaces.UnitOfWorks;
using HospitalApi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Features.Appointments.Queries.GetAllAppointments
{
    public class GetAllAppointmentsQueryHandler : IRequestHandler<GetAllAppointmentsQueryRequest, IList<GetAllAppointmentsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllAppointmentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IList<GetAllAppointmentsQueryResponse>> Handle(GetAllAppointmentsQueryRequest request, CancellationToken cancellationToken)
        {
            var appointments = await unitOfWork.GetReadRepository<Appointment>().GetAllAsync();
            var users = await unitOfWork.GetReadRepository<User>().GetAllAsync();

            List<GetAllAppointmentsQueryResponse> map = new List<GetAllAppointmentsQueryResponse>();

            foreach (var appointment in appointments)
            {
                var patient = users.FirstOrDefault(u => u.Id == appointment.PatientId).UsernameSurname;
                var doctor = users.FirstOrDefault(u => u.Id == appointment.DoctorId).UsernameSurname;

                map.Add(new GetAllAppointmentsQueryResponse
                {
                    Id = appointment.Id,
                    AppointmentDate = appointment.AppointmentDate,
                    AppointmentTime =appointment.AppointmentTime,
                    PatientName = patient,
                    DoctorName = doctor,
                    Description = appointment.Description,
                    IsApproved = appointment.IsApproved,
                });
            }

            return map;
        }
    }
}

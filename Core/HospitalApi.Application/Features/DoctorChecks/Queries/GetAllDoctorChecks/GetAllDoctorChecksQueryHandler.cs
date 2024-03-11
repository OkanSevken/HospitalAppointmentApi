using HospitalApi.Application.DTOs;
using HospitalApi.Application.Features.Appointments.Queries.GetAllAppointments;
using HospitalApi.Application.Interfaces.AutoMapper;
using HospitalApi.Application.Interfaces.UnitOfWorks;
using HospitalApi.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Features.DoctorChecks.Queries.GetAllDoctorChecks
{
    public class GetAllDoctorChecksQueryHandler : IRequestHandler<GetAllDoctorChecksQueryRequest, IList<GetAllDoctorChecksQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllDoctorChecksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IList<GetAllDoctorChecksQueryResponse>> Handle(GetAllDoctorChecksQueryRequest request, CancellationToken cancellationToken)
        {
            var doctorChecks = await unitOfWork.GetReadRepository<DoctorCheck>().GetAllAsync(include:x=>x.Include(b=>b.Appointment));

            var appointment = mapper.Map<AppointmentDto, Appointment>(new Appointment());

            var map=mapper.Map<GetAllDoctorChecksQueryResponse, DoctorCheck>(doctorChecks);
            return map;
        }
    }
}

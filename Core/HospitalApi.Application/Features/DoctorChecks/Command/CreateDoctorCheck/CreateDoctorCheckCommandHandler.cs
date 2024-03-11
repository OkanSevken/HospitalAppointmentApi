using HospitalApi.Application.Features.DoctorChecks.Command.CreateDoctorCheckCommand;
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

namespace HospitalApi.Application.Features.DoctorChecks.Command.CreateDoctorCheck
{
    public class CreateDoctorCheckCommandHandler : IRequestHandler<CreateDoctorCheckCommandRequest, Unit>
    {

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CreateDoctorCheckCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<Unit> Handle(CreateDoctorCheckCommandRequest request, CancellationToken cancellationToken)
        {
            DoctorCheck doctorCheck = new(request.Description, request.AppointmentId);

            await unitOfWork.GetWriteRepository<DoctorCheck>().AddAsync(doctorCheck);

            //doctorCheck.CreaterUserId= request.UserId 

            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}

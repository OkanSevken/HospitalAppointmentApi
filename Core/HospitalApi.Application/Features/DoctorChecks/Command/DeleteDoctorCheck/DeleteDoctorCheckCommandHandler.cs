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

namespace HospitalApi.Application.Features.DoctorChecks.Command.DeleteDoctorCheck
{
    public class DeleteDoctorCheckCommandHandler : IRequestHandler<DeleteDoctorCheckCommandRequest, Unit>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;

        public DeleteDoctorCheckCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<Unit> Handle(DeleteDoctorCheckCommandRequest request, CancellationToken cancellationToken)
        {
            var doctorCheck = await unitOfWork.GetReadRepository<DoctorCheck>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            doctorCheck.IsDeleted = true;

            doctorCheck.LastModifyDate = DateTime.Now;

            doctorCheck.LastUserId = request.UserId;

            await unitOfWork.GetWriteRepository<DoctorCheck>().UpdateAsync(doctorCheck);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}

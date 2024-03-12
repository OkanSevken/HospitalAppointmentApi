using HospitalApi.Application.Features.DoctorChecks.Command.CreateDoctorCheckCommand;
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

namespace HospitalApi.Application.Features.DoctorChecks.Command.CreateDoctorCheck
{
    public class CreateDoctorCheckCommandHandler : IRequestHandler<CreateDoctorCheckCommandRequest, Unit>
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CreateDoctorCheckCommandHandler(UserManager<User> userManager,IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<Unit> Handle(CreateDoctorCheckCommandRequest request, CancellationToken cancellationToken)
        {
            DoctorCheck doctorCheck = new(request.Description, request.AppointmentId);

            await unitOfWork.GetWriteRepository<DoctorCheck>().AddAsync(doctorCheck);

            var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);  // Login yapan kullanıcının bilgilerini çektim

            doctorCheck.CreaterUserId = user.Id;

            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}

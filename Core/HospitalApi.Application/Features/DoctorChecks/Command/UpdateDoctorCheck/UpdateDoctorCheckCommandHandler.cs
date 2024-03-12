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

namespace HospitalApi.Application.Features.DoctorChecks.Command.UpdateDoctorCheck
{
    public class UpdateDoctorCheckCommandHandler : IRequestHandler<UpdateDoctorCheckCommandRequest, Unit>
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public UpdateDoctorCheckCommandHandler(UserManager<User> userManager,IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateDoctorCheckCommandRequest request, CancellationToken cancellationToken)
        {
            var doctorCheck = await unitOfWork.GetReadRepository<DoctorCheck>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            var map = mapper.Map<DoctorCheck, UpdateDoctorCheckCommandRequest>(request);  

            map.LastModifyDate = DateTime.Now;

            map.CreatedDate = doctorCheck.CreatedDate;  
            map.AppointmentId = doctorCheck.AppointmentId;

            var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User); // Login yapan kullanıcının bilgilerini çektim
            map.LastUserId = user.Id;                                                        // Update yapan son kullanıcıya çektiğim id'yi atadım. 

            await unitOfWork.GetWriteRepository<DoctorCheck>().UpdateAsync(map);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}

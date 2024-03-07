using HospitalApi.Application.Interfaces.AutoMapper;
using HospitalApi.Application.Interfaces.UnitOfWorks;
using HospitalApi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Features.Appointments.Command.UpdateAppointment
{
    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateAppointmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper )
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateAppointmentCommandRequest request, CancellationToken cancellationToken)
        {
            var appointment=await unitOfWork.GetReadRepository<Appointment>().GetAsync(x=>x.Id==request.Id && !x.IsDeleted);

            var map = mapper.Map<Appointment, UpdateAppointmentCommandRequest>(request);  // Appointment ve UpdateAppointmentCommandRequest'i eşledim.
                                                                                          // Ve Appointment'ı döndüm

            map.LastModifyDate = DateTime.Now;

            map.CreatedDate = appointment.CreatedDate;   // Güncelleme yaparken map'ten gelen CreatedDate'i de DateTime.Now ile güncellememesi için
                                                         // appointment'tan gelen var olan CreatedDate'i ona atadım.

            

            await unitOfWork.GetWriteRepository<Appointment>().UpdateAsync(map);
            await unitOfWork.SaveAsync();

            return Unit.Value;   
        }
    }
}

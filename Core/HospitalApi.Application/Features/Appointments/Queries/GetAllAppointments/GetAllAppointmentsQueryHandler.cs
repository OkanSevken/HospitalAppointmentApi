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
            var appointments = await unitOfWork.GetReadRepository<Appointment>().GetAllAsync();  //Veri tabanından bütün randevu kayıtlarını appointments
                                                                                                 //değişkenine bir liste olarak dönüyorum.


            var map=mapper.Map<GetAllAppointmentsQueryResponse, Appointment>(appointments);    //Mapper classındaki map parametreleri;TDestination => GetAllAppointmentsQueryResponse
            return map;                                                                        // Ve GetAllAppointmentsQueryResponse'u döndüm .                                                                                 //                                     TSource => Appointment oldu.




            //List<GetAllAppointmentsQueryResponse> response = new();     // Bu listeyi new'leyip foreach içinde dönen response'u bu listeye ekliyorum.

            //foreach (var appointment in appointments)
            //{
            //    response.Add( new GetAllAppointmentsQueryResponse
            //    {
            //        AppointmentDate = appointment.AppointmentDate,            
            //        AppointmentTime = appointment.AppointmentTime,          //Veri tabanından gelen randevu kayıtlarını new'lediğim Response'a ekliyorum.
            //        PatientId = appointment.PatientId,
            //        DoctorId = appointment.DoctorId,
            //        Description = appointment.Description,
            //        IsApproved = appointment.IsApproved,
            //    });
            //}
            //return response;    
        }
    }
}

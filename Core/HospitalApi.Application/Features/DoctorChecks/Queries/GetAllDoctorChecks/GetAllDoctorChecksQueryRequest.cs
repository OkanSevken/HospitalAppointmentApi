using HospitalApi.Application.Features.Appointments.Queries.GetAllAppointments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Features.DoctorChecks.Queries.GetAllDoctorChecks
{
    public class GetAllDoctorChecksQueryRequest : IRequest<IList<GetAllDoctorChecksQueryResponse>>
    {
    }
}

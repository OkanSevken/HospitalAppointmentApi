using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Features.Appointments.Queries.GetAllAppointments
{
    public class GetAllAppointmentsQueryRequest : IRequest<IList<GetAllAppointmentsQueryResponse>> //Birden fazla veri dönmek için list içine aldım.
    {
    }
}

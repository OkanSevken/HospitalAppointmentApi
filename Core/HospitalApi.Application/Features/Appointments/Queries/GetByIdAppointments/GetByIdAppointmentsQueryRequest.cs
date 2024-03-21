using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Features.Appointments.Queries.GetByIdAppointments
{
    public class GetByIdAppointmentsQueryRequest : IRequest<GetByIdAppointmentsQueryResponse>
    {
        public int Id { get; set; }

        public GetByIdAppointmentsQueryRequest(int id)
        {
            Id = id;
        }
    }
}

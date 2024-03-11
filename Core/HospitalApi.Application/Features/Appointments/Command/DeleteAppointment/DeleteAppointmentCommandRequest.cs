using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Features.Appointments.Command.DeleteAppointment
{
    public class DeleteAppointmentCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}

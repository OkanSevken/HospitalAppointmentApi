using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Features.DoctorChecks.Command.CreateDoctorCheckCommand
{
    public class CreateDoctorCheckCommandRequest : IRequest<Unit>
    {
        public string Description { get; set; }
        public int AppointmentId { get; set; }
    }
}

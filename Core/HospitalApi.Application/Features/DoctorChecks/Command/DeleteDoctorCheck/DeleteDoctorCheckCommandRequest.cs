using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Features.DoctorChecks.Command.DeleteDoctorCheck
{
    public class DeleteDoctorCheckCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}

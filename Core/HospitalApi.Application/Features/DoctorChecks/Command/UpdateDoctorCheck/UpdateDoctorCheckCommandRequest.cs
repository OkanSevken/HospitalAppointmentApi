using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Features.DoctorChecks.Command.UpdateDoctorCheck
{
    public class UpdateDoctorCheckCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        
    }
}

using HospitalApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Features.DoctorChecks.Queries.GetAllDoctorChecks
{
    public class GetAllDoctorChecksQueryResponse
    {
        public string Description { get; set; }
        public AppointmentDto Appointment { get; set; }
    }
}

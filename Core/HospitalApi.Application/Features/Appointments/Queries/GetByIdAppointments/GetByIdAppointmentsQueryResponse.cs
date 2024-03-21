using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Features.Appointments.Queries.GetByIdAppointments
{
    public class GetByIdAppointmentsQueryResponse
    {
        public DateTime AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Features.Appointments.Queries.GetAllAppointments
{
    public class GetAllAppointmentsQueryResponse
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }
    }
}

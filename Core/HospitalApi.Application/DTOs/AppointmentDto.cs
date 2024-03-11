using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.DTOs
{
    public class AppointmentDto
    {
        public DateTime AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    }
}

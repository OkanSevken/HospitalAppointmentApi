using HospitalApi.Domain.Cammon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Domain.Entities
{
    public class DoctorCheck : EntityBase
    {
        public DoctorCheck()
        {
            
        }

        public DoctorCheck(string description, int appointmentId)
        {
            Description = description;
            AppointmentId = appointmentId;
        }

        public string Description { get; set; }
        public int AppointmentId { get; set; }    
        public Appointment Appointment { get; set; }
    }
}

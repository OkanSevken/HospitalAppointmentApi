using HospitalApi.Domain.Cammon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Domain.Entities
{
    public class Appointment : EntityBase
    {
        public Appointment()
        {
            
        }

        public Appointment(int patientId, DateTime appointmentDate, TimeSpan appointmentTime, int doctorId , string description, bool isApproved)
        {
            PatientId = patientId;
            AppointmentDate = appointmentDate;
            AppointmentTime = appointmentTime;
            DoctorId = doctorId;
            Description = description;
            IsApproved = isApproved;
        }

        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }
        public ICollection<DoctorCheck> DoctorChecks { get; set; }
    }
}

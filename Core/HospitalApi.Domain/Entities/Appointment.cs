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

        //public Appointment(DateTime appointmentDate, int doctorId, string description,int patientId)
        //{
        //    AppointmentDate = appointmentDate;
        //    //AppointmentTime = appointmentTime;                                    //Create Handle sınıfında isApproved'ı almamak için bu ctor'u oluşturdum.
        //    DoctorId = doctorId;
        //    Description = description;
        //    PatientId = patientId;
        //}

        public Appointment(int patientId, DateTime appointmentDate ,int doctorId , string description,string appointmentTime)
        {
            PatientId = patientId;
            AppointmentDate = appointmentDate;
            DoctorId = doctorId;
            Description = description;
            AppointmentTime = appointmentTime;
        }

        public DateTime AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; } = true;
        public ICollection<DoctorCheck> DoctorChecks { get; set; }
    }
}

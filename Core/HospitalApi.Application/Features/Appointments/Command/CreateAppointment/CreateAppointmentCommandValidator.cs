using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Features.Appointments.Command.CreateAppointment
{
    public class CreateAppointmentCommandValidator : AbstractValidator<CreateAppointmentCommandRequest>
    {
        public CreateAppointmentCommandValidator()
        {
            RuleFor(x => x.AppointmentDate)
                .NotEmpty()
                .WithName("Randevu Günü");

            RuleFor(x => x.AppointmentTime)
                .NotEmpty()
                .WithName("Randevu Saati");

            RuleFor(x => x.PatientId)
                .GreaterThan(0)
                .WithName("Hasta");

            RuleFor(x => x.DoctorId)
                .GreaterThan(0)
                .WithName("Doktor");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithName("Açıklama");
        }
    }
}

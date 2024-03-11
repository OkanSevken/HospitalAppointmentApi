using FluentValidation;
using HospitalApi.Application.Features.DoctorChecks.Command.CreateDoctorCheckCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Features.DoctorChecks.Command.CreateDoctorCheck
{
    public class CreateDoctorCheckCommandValidator : AbstractValidator<CreateDoctorCheckCommandRequest>
    {
        public CreateDoctorCheckCommandValidator()
        {
            RuleFor(x => x.Description)
         .NotEmpty()
         .WithName("Randevu Açıklama");


         RuleFor(x => x.AppointmentId)
                .GreaterThan(0)
                .WithName("Randevu Id");

        }
    }
}

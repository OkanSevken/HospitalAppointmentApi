using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Features.DoctorChecks.Command.UpdateDoctorCheck
{
    public class UpdateDoctorCheckCommandValidator : AbstractValidator<UpdateDoctorCheckCommandRequest>
    {
        public UpdateDoctorCheckCommandValidator()
        {
            RuleFor(x => x.Id)
              .GreaterThan(0);

            RuleFor(x => x.Description)
           .NotEmpty()
           .WithName("Açıklama");
        }
    }
}

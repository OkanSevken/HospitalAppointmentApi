using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Features.DoctorChecks.Command.DeleteDoctorCheck
{
    public class DeleteDoctorCheckCommandValidator : AbstractValidator<DeleteDoctorCheckCommandRequest>
    {
        public DeleteDoctorCheckCommandValidator()
        {
            RuleFor(x => x.Id)
              .GreaterThan(0);
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Features.Appointments.Command.DeleteAppointment
{
    public class DeleteAppointmentCommandValidator : AbstractValidator<DeleteAppointmentCommandRequest>
    {
        public DeleteAppointmentCommandValidator()
        {
            RuleFor(x => x.Id)
              .GreaterThan(0);
        }
    }
}

﻿using HospitalApi.Application.Interfaces.UnitOfWorks;
using HospitalApi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Features.Appointments.Command.DeleteAppointment
{
    public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteAppointmentCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteAppointmentCommandRequest request, CancellationToken cancellationToken)
        {
            var appointment= await unitOfWork.GetReadRepository<Appointment>().GetAsync(x=> x.Id ==request.Id && !x.IsDeleted);

            appointment.IsDeleted = true;

            appointment.LastModifyDate = DateTime.Now;

            await unitOfWork.GetWriteRepository<Appointment>().UpdateAsync(appointment);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
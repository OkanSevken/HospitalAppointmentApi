using HospitalApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Persistence.Configurations
{
    public class DoctorCheckConfiguration : IEntityTypeConfiguration<DoctorCheck>
    {
        public void Configure(EntityTypeBuilder<DoctorCheck> builder)
        {
            builder.Property(x => x.Description).HasMaxLength(100);
        }
    }
}

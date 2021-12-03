using EFCRelations.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCRelations.ModelBuilding
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            //builder
            //    .HasKey(x => new { x.Id, x.Egn });


            builder
                .Property(x => x.StartWorkDate)
                .HasColumnName("StartedOn");


            builder
                .HasOne(x => x.Department)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
                
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kholy.IKEA.DAL.Common.Enums;
using Kholy.IKEA.DAL.Persistence.Data.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kholy.IKEA.DAL.Persistence.Data.Configurations.Employee
{
    public class DepartmentConfigClass : BaseAuditableConfig<int, Entites.Employee.Employee>
    {
        public override void Configure(EntityTypeBuilder<Entites.Employee.Employee> builder)
        {
            builder.Property(D => D.ID).UseIdentityColumn(10, 10);
            base.Configure(builder);

            builder.Property(E => E.Name).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(E => E.Address).HasColumnType("nvarchar(100)").IsRequired(false);

            builder.Property(E => E.gender).HasConversion(
                (gender) => gender.ToString(),
                (gender) => (Gender)Enum.Parse(typeof(Gender), gender));

            builder.Property(E => E.EmployeeType).HasConversion(
                 (EmployeeType) => EmployeeType.ToString(),
                (EmployeeType) => (EmpType)Enum.Parse(typeof(EmpType), EmployeeType));
        }
    }
}

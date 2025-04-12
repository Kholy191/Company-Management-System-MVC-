using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kholy.IKEA.DAL.Common.Entites;
using Kholy.IKEA.DAL.Persistence.Data.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kholy.IKEA.DAL.Persistence.Data.Configurations.Department
{
    public class DepartmentConfigClass : BaseAuditableConfig<int , Entites.Department.Department>
    {
        public override void Configure(EntityTypeBuilder<Entites.Department.Department> builder)
        {
            builder.Property(D => D.ID).UseIdentityColumn(10,10);
            base.Configure(builder);
        }
    }
}

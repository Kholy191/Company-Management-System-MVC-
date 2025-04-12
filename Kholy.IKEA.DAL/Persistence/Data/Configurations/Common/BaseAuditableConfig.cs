using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kholy.IKEA.DAL.Common.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kholy.IKEA.DAL.Persistence.Data.Configurations.Common
{
    public class BaseAuditableConfig<Tkey, TEntity> : BaseEntityConfigurations<Tkey, TEntity> 
        where Tkey : IEquatable<Tkey>
        where TEntity : BaseAuditableEntity<Tkey>
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);
            builder.Property(D => D.CreatedBy).HasColumnType("varchar(50)");
            builder.Property(D => D.LastModifiedBy).HasColumnType("varchar(50)");
            builder.Property(D => D.CreatedOn).HasDefaultValueSql("GETUTCDate()");
            builder.Property(D => D.LastModifiedOn).HasComputedColumnSql("GETUTCDate()");

        }
    }
}

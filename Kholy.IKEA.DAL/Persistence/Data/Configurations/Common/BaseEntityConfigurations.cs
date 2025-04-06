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
    public class BaseEntityConfigurations <Tkey, TEntity> : IEntityTypeConfiguration<TEntity> 
        where Tkey :IEquatable<Tkey>
        where TEntity : BaseEntity<Tkey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(D => D.ID);
        }
    }
}

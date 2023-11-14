using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sibers.Data.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.Data.Entities.Classes.Base
{
    [NotMapped]
    public class EntityBase<T> : IEntityConfiguration<T> where T : class
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            CustomConfigure(builder);
        }

        public virtual void CustomConfigure(EntityTypeBuilder<T> pBuilder)
        {

        }
    }
}

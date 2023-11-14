using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.Data.Entities.Interfaces
{
    internal interface IEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : class
    {
        public void CustomConfigure(EntityTypeBuilder<T> pBuilder);
    }
}

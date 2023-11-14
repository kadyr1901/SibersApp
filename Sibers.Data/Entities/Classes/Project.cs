using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sibers.Data.Entities.Classes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.Data.Entities.Classes
{
    public class Project : EntityBase<Project>
    {
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public string? CustomerCompany { get; set; }
        public string? ExecutionCompany { get; set; } 

        public List<Assignment> Assignments { get; set; }

        public override void CustomConfigure(EntityTypeBuilder<Project> pBuilder)
        {
            base.CustomConfigure(pBuilder);
        }
    }
}

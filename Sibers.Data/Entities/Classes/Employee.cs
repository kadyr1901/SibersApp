using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sibers.Data.Entities.Classes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.Data.Entities.Classes
{
    public class Employee : EntityBase<Employee>
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public List<Assignment>? AuthoredAssignments { get; set; }
        public List<Assignment>? AssignedAssignments { get; set; } 

        public override void CustomConfigure(EntityTypeBuilder<Employee> pBuilder)
        {
            pBuilder
            .HasMany(e => e.AuthoredAssignments)
            .WithOne(a => a.Author)
            .HasForeignKey(a => a.AuthorId);

            pBuilder
            .HasMany(e => e.AssignedAssignments)
            .WithOne(a => a.Assignee)
            .HasForeignKey(a => a.AssigneeId);
        }
    }
}

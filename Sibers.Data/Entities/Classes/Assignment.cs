using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sibers.Data.Entities.Classes.Base;
using Sibers.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.Data.Entities.Classes
{
    public class Assignment : EntityBase<Assignment>
    {
        public int AssignmentId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }

        public int AuthorId { get; set; } // Foreign key for the author (employee)
        public Employee Author { get; set; } // Navigation property to the author

        public int AssigneeId { get; set; } // Foreign key for the assignee (employee)
        public Employee Assignee { get; set; } // Navigation property to the assignee
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } = null;
        public AssignmentStatus Status { get; set; }
        public Priority Priority { get; set; }
        public string Comment { get; set; }

        public int ProjectId { get; set; } // Foreign key for the assignee (employee)
        public Project Project { get; set; } // Navigation property to the assignee


        public override void CustomConfigure(EntityTypeBuilder<Assignment> pBuilder)
        {
            pBuilder
           .HasOne(e => e.Project)
           .WithMany(i=>i.Assignments)
           .HasForeignKey(a => a.ProjectId);
        }
    }
}

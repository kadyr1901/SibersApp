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
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int AuthorId { get; set; } 
        public Employee Author { get; set; } 
        public int? AssigneeId { get; set; } 
        public Employee? Assignee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } = null;
        public AssignmentStatus Status { get; set; } = AssignmentStatus.ToDo;
        public Priority Priority { get; set; } = Priority.Low;
        public string? Comment { get; set; }

        public int ProjectId { get; set; } 
        public Project Project { get; set; } 


        public override void CustomConfigure(EntityTypeBuilder<Assignment> pBuilder)
        {
            pBuilder
           .HasOne(e => e.Project)
           .WithMany(i=>i.Assignments)
           .HasForeignKey(a => a.ProjectId);
        }
    }
}

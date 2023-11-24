using Microsoft.EntityFrameworkCore;
using Sibers.Core.Repositories.Base;
using Sibers.Data;
using Sibers.Data.Entities.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.Core.Repositories
{
    public class ProjectRepository : SibersRepository<Project>, IProjectRepository
    {
        public ProjectRepository(SibersDbContext db) : base(db)
        {
            
        }

        public async Task DeleteAssignment(int projectId, int assignmentId)
        {
            var assignment=await _db.Set<Assignment>()
                                   .FirstOrDefaultAsync(i=>i.AssigneeId == assignmentId && i.Project.ProjectId==projectId);
            if (assignment != null)
            {
                _db.Remove(assignment);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Задача этого проекта не найдена!");
            }
        }

        public async Task DeleteAssignments(int projectId, IQueryable<int> assignmentsIds)
        {
            var assignments = await _db.Set<Assignment>()
                                   .Where(i => assignmentsIds.Contains(i.AssignmentId) && i.Project.ProjectId == projectId).ToListAsync();
            if (assignments.Count>0)
            {
                _db.RemoveRange(assignments);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Задачи этого проекта не найдена!");
            }
        }
    }
}

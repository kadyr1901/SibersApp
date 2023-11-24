using Microsoft.EntityFrameworkCore;
using Sibers.Core.Repositories.Base;
using Sibers.Data;
using Sibers.Data.Entities.Classes;
using Sibers.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.Core.Repositories
{
    public class AssignmentRepository : SibersRepository<Assignment>, IAssignmentRepository
    {
        public AssignmentRepository(SibersDbContext db) : base(db)
        {
        }
        public async Task ChangeAssignee(int assignmentId, int? employeeId)
        {
            try
            {
                var assignment = await _db.Set<Assignment>().FirstOrDefaultAsync(i => i.AssignmentId == assignmentId);
                if(assignment == null)
                {
                    throw new Exception("Задача не найдена!");
                }
                assignment.AssigneeId = employeeId;
                await _db.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task ChangeAuthor(int assignmentId, int employeeId)
        {
            try 
            {
                var assignment = await _db.Set<Assignment>().FirstOrDefaultAsync(i => i.AssignmentId == assignmentId);
                if (assignment == null)
                {
                    throw new Exception("Задача не найдена!");
                }
                assignment.AuthorId = employeeId;
                await _db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
}

        public async Task<Assignment> CloseAssignment(int assignmentId)
        {
            try
            {
                var assignment = await _db.Set<Assignment>().FirstOrDefaultAsync(i => i.AssignmentId == assignmentId);
                if (assignment == null)
                {
                    throw new Exception("Задача не найдена!");
                }
                assignment.EndDate = DateTime.Now;
                assignment.Status = AssignmentStatus.Done;
                await _db.SaveChangesAsync();
                return assignment;
            }
            catch
            {
                throw;
            }
        }

        public async Task SetPriority(int assignmentId,Priority priority)
        {
            try
            {
                var assignment = await _db.Set<Assignment>().FirstOrDefaultAsync(i => i.AssignmentId == assignmentId);
                if (assignment == null)
                {
                    throw new Exception("Задача не найдена!");
                }
                assignment.Priority = priority;
                await _db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task SetStatus(int assignmentId, AssignmentStatus status)
        {
            try
            {
                var assignment = await _db.Set<Assignment>().FirstOrDefaultAsync(i => i.AssignmentId == assignmentId);
                if (assignment == null)
                {
                    throw new Exception("Задача не найдена!");
                }
                assignment.Status = status;
                await _db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}

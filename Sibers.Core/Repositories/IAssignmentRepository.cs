using Sibers.Core.Repositories.Base;
using Sibers.Data.Entities.Classes;
using Sibers.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.Core.Repositories
{
    public interface IAssignmentRepository : ISibersRepository<Assignment> 
    {
        Task ChangeAuthor(int assignmentId,int employeeId);
        Task ChangeAssignee(int assignmentId,int? employeeId);
        Task SetStatus(int assignmentId, AssignmentStatus status);
        Task<Assignment> CloseAssignment(int assignmentId);
        Task SetPriority(int assignmentId, Priority priority);
    }
}

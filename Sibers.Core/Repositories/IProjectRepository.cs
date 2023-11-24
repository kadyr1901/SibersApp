using Sibers.Core.Repositories.Base;
using Sibers.Data.Entities.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.Core.Repositories
{
    public interface IProjectRepository : ISibersRepository<Project>
    {
        Task DeleteAssignment(int projectId,int assignmentId);

        Task DeleteAssignments(int projectId, IQueryable<int> assignmentsIds);
    }
}

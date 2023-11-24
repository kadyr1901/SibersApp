using Microsoft.AspNetCore.Mvc;
using Sibers.Core.Repositories;
using Sibers.Data.Entities.Classes;
using Sibers.Data.Entities.Enums;
using System.Reflection.Metadata;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sibers.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentRepository _assignmentService;

        public AssignmentController(IAssignmentRepository assignmentService)
        {
            _assignmentService=assignmentService;
        }

        [HttpPost]
        [Route("Open")]
        public async Task<ActionResult<Assignment>> Create([FromBody] Assignment assignment)
        {
            return await _assignmentService.AddAsync(assignment);
        }

        [HttpPost]
        [Route("Close")]
        public async Task<ActionResult<Assignment>> Close(int assignmentID)
        {
            return await _assignmentService.CloseAssignment(assignmentID);
        }

        [HttpPost]
        [Route("SetStatus")]
        public async Task<ActionResult> SetStatus(int assignmentID,[FromBody] AssignmentStatus status)
        {
            try
            {
                await _assignmentService.SetStatus(assignmentID,status);
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500);
            }
            
        }

        [HttpPost]
        [Route("SetPriority")]
        public async Task<ActionResult> SetPriority(int assignmentID, [FromBody] Priority priority)
        {
            try
            {
                await _assignmentService.SetPriority(assignmentID, priority);
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500);
            }

        }

        [HttpPost]
        [Route("ChangeAuthor")]
        public async Task<ActionResult> ChangeAuthor([FromQuery]int assignmentID, [FromQuery]int employeeID)
        {
            try
            {
                await _assignmentService.ChangeAuthor(assignmentID, employeeID);
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500);
            }

        }

        [HttpPost]
        [Route("ChangeAssignee")]
        public async Task<ActionResult> ChangeAssignee([FromQuery] int assignmentID, [FromQuery] int employeeID)
        {
            try
            {
                await _assignmentService.ChangeAssignee(assignmentID, employeeID);return StatusCode(200);
            }
            catch
            {
                return StatusCode(500);
            }

        }
    }
}

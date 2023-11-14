using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.Data.Entities.Enums
{
    public enum AssignmentStatus
    {
        [Description("Сделать")]
        ToDo = 1,
        [Description("В работе")]
        InProgress = 2,
        [Description("Сделано")]
        Done = 3
    }
}

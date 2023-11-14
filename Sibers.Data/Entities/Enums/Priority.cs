using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.Data.Entities.Enums
{
    public enum Priority
    {
        [Description("Низкий")]
        Low = 1,

        [Description("Средний")]
        Medium = 2,

        [Description("Высокий")]
        High = 3,

        [Description("Срочный")]
        Urgent = 4
    }
}

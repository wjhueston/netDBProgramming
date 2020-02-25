using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign_01_CSVIO
{
    class Task : Ticket
    {
        public string projectName { get; set; }
        public string dueDate { get; set; }
        public Task(int id, string summ, string stat, string prio, string sub, string assign, string watch, string proj, string due) : base(id, summ, stat, prio, sub, assign, watch)
        {
            projectName = proj;
            dueDate = due;
        }
    }
}

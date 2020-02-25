using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign_01_CSVIO
{
    class Enhancement : Ticket
    {
        public string software { get; set; }
        public double cost { get; set; }
        public string reason { get; set; }
        public double estimate { get; set; }
        public Enhancement(int id, string summ, string stat, string prio, string sub, string assign, string watch, string soft, double cos, string rea, double est) : base(id, summ, stat, prio, sub, assign, watch)
        {
            idNumber = id;
            summary = summ;
            status = stat;
            priority = prio;
            submitter = sub;
            assigned = assign;
            watchers = watch;
            software = soft;
            cost = cos;
            reason = rea;
            estimate = est;
        }
    }
}

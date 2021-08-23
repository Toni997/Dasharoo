using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DasharooAPI.Data
{
    public class RecordSupporter
    {
        public int RecordId { get; set; }
        public Record Record { get; set; }

        public string SupporterId { get; set; }
        public User Supporter { get; set; }
    }
}

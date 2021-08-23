using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DasharooAPI.Data
{
    public class RecordAuthor
    {
        public int RecordId { get; set; }
        public Record Record { get; set; }

        public string AuthorId { get; set; }
        public User Author { get; set; }
    }
}

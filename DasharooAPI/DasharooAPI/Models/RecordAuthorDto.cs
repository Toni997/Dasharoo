using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DasharooAPI.Models
{
    public class RecordAuthorDto
    {
        public string AuthorId { get; set; }
        public UserOnRecordDto Author { get; set; }
    }
}

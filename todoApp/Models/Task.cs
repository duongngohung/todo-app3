using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoApp.Models
{
    public class Task
    {
        public Guid taskId { get; set; }
        public string taskName { get; set; }
        public DateTime createdDate { get; set; }
        public bool status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestJob.Validation
{
    public class ErrorModel
    {
        public Dictionary<string,string> Errors { get; set; }
        public string Message { get; set; }
    }
}

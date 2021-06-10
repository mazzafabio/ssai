using SSAI.Entity.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSAI.Model.Response
{
    public class MessageResponse
    {
        public object model { get; set; }
        public string message { get; set; }
    }
}

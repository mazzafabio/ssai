using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSAI.Model.Response
{
    public class GenericResponse<T>
    {
        public string message { get; set; }
        public bool error { get; set; }
        public T model { get; set; }
    }
}

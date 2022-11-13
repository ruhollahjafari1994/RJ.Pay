using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;

namespace RJ.Pay.Common.Helpers
{
    public class ReturnMessage
    {
        public bool status { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public string message { get; set; }

    }
   public class ReturnResult<T>
    {
        public ReturnResult()
        {

        }

        public bool Success { get; set; }
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public object Result { get; set; } = null;
    }
   
}
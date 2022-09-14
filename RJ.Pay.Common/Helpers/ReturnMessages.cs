using System;
using System.Collections.Generic;
using System.Linq;
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
}
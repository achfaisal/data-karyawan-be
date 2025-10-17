using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataKaryawan.Models
{
    public class RetvalResponse
    {
        public string Retval { get; set; }
        public string Total { get; set; }
        public object Data { get; set; }
    }
}

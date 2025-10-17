using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataKaryawan.Models
{
    public class DataEmp
    {
        #region DataEmp
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalRow { get; set; }
        #endregion

        #region Entities
        public string emp_name { get; set; }
        public string emp_no { get; set; }
        public string emp_email { get; set; }
        public string worklocation { get; set; }
        public string alamat { get; set; }
        public string no_hp { get; set; }
        public string jabatan { get; set; }
        public string join_date { get; set; }
        public string spv_emp_no { get; set; }
        public string spv_name { get; set; }
        public string spv_email { get; set; }
        public string mgr_emp_no { get; set; }
        public string mgr_name { get; set; }
        public string mgr_email { get; set; }
        public int id { get; set; }
        #endregion
    }
}

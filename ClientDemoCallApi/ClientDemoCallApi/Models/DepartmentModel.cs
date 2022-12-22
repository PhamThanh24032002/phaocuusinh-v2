using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ClientDemoCallApi.Models
{
    public class DepartmentModel
    {
        [DisplayName("Mã phòng ban")]
        public string DepartId { get; set; }
        [DisplayName("Tên phòng ban")]
        public string DepartName { get; set; }
        [DisplayName("Số lượng nhân viên")]
        public int TotalEmployees { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCallAPI.Models
{
    public class Department
    {
        [DisplayName("Mã phòng ban")]
        public string DepartId { get; set; }
        [DisplayName("Tên phòng ban")]
        public string DepartName { get; set; }
        [DisplayName("Số lượng nhân viên")]
        public int TotalEmployees { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}

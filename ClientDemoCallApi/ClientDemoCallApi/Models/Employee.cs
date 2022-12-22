using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCallAPI.Models
{
    public class Employee
    {
        [DisplayName("Id nhân viên")]
        public string EmpId { get; set; }

        [DisplayName("Tên nhân viên")]
        public string FullName { get; set; }

        [DisplayName("Giới tính")]
        public bool Gender { get; set; }

        [DisplayName("Sinh nhật")]
        [DataType(DataType.DateTime)]
        public DateTime Birthday { get; set; }

        [DisplayName("Địa chỉ")]
        public string Address { get; set; }

        public string DepartId { get; set; }

        [DisplayName("Vị trí")]
        public string Position { get; set; }

        [DisplayName("Lương")]
        public float Salary { get; set; }

        [DisplayName("Tên phòng ban")]
        public string DepartName { get; set; }

        public Department Department { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCallAPI.Models
{
    public class ModelEmployee
    {
        public string EmpId { get; set; }
        public string FullName { get; set; }
        public bool Gender { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string DepartId { get; set; }
        public string Position { get; set; }
        public float Salary { get; set; }
        public string DepartName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCallAPI.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public string DepartId { get; set; }
        public string DepartName { get; set; }
        public int TotalEmployees { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}

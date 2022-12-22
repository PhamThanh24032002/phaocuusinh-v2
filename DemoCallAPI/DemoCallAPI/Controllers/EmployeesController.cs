using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoCallAPI.Models;

namespace DemoCallAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public EmployeesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public IEnumerable<ModelEmployee> GetEmployees()
        {
            var employees = from s in _context.Employees
                            select new ModelEmployee
                            {
                                EmpId = s.EmpId,
                                FullName = s.FullName,
                                Address = s.Address,
                                Birthday = s.Birthday,
                                DepartId = s.DepartId,
                                Gender = s.Gender,
                                Position = s.Position,
                                Salary = s.Salary,
                                DepartName = s.Department.DepartName
                            };
            return employees;
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee =  _context.Employees.FirstOrDefault(t => t.EmpId == id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                var employeeModel = from s in _context.Employees.Where(s=>s.EmpId == id)
                                select new ModelEmployee
                                {
                                    EmpId = s.EmpId,
                                    FullName = s.FullName,
                                    Address = s.Address,
                                    Birthday = s.Birthday,
                                    DepartId = s.DepartId,
                                    Gender = s.Gender,
                                    Position = s.Position,
                                    Salary = s.Salary,
                                    DepartName = s.Department.DepartName
                                };
                return Ok(employeeModel);
            }

        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee([FromRoute] string id, [FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.EmpId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<IActionResult> PostEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.EmpId }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        private bool EmployeeExists(string id)
        {
            return _context.Employees.Any(e => e.EmpId == id);
        }
    }
}
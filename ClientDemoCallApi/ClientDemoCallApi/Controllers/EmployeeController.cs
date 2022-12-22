using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ClientDemoCallApi.Models;
using DemoCallAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ClientDemoCallApi.Controllers
{
    public class EmployeeController : Controller
    {
        string host_api = "http://localhost:61303/";
        HttpClient client = new HttpClient();

        public async Task<IActionResult> Index()
        {
            client.BaseAddress = new Uri(host_api);
            var result = await client.GetStringAsync("api/Employees");
            List<ModelEmployee> employees = JsonConvert.DeserializeObject<List<ModelEmployee>>(result);
            return View(employees);
        }

        public async Task<IActionResult> Create()
        {
            client.BaseAddress = new Uri(host_api);
            var result = await client.GetStringAsync("api/Departments");
            List<DepartmentModel> departments = JsonConvert.DeserializeObject<List<DepartmentModel>>(result);
            ViewBag.departments = new SelectList(departments, "DepartId", "DepartName");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            client.BaseAddress = new Uri(host_api);
            var result = await client.PostAsJsonAsync<Employee>("api/Employees", employee);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string empId)
        {
            client.BaseAddress = new Uri(host_api);
            var result = await client.DeleteAsync("api/Employees/" + empId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string empId)
        {
            client.BaseAddress = new Uri(host_api);
            var result = await client.GetStringAsync("api/Employees/" + empId);
            ModelEmployee em = JsonConvert.DeserializeObject<List<ModelEmployee>>(result)[0];
            return View(em);
        }


        public async Task<IActionResult> Edit(string empId)
        {
            client.BaseAddress = new Uri(host_api);
            var result = await client.GetStringAsync("api/Departments");
            List<DepartmentModel> departments = JsonConvert.DeserializeObject<List<DepartmentModel>>(result);
            ViewBag.departments = new SelectList(departments, "DepartId", "DepartName");

            var data_emp = await client.GetStringAsync("api/Employees/" + empId);
            ModelEmployee modelEmployee = JsonConvert.DeserializeObject<List<ModelEmployee>>(data_emp)[0];
            Employee s = new Employee {
                                        EmpId = modelEmployee.EmpId,
                                        FullName = modelEmployee.FullName,
                                        Gender = modelEmployee.Gender,
                                        Birthday = modelEmployee.Birthday,
                                        Address = modelEmployee.Address,
                                        DepartId = modelEmployee.DepartId,
                                        Position = modelEmployee.Position,
                                        Salary = modelEmployee.Salary
                                    };
            return View(s);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Employee emp)
        {
            client.BaseAddress = new Uri(host_api);
            var result = await client.PutAsJsonAsync<Employee>("api/Employees/" + emp.EmpId, emp);

            return RedirectToAction("Index");
        }
    }
}
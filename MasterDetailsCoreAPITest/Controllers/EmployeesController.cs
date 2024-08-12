using MasterDetailsCoreAPITest.Models;
using MasterDetailsCoreAPITest.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MasterDetailsCoreAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _environment;

        public EmployeesController(AppDbContext db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            List<Employee> employees = _db.Employees.Include(e => e.Experiences).ToList();
            string jsonString = JsonConvert.SerializeObject(employees, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Content(jsonString, "application/json");
        }
        [HttpGet("{employeeId}")]
        public IActionResult GetEmployeeById(int employeeId) 
        {
            Employee employee = _db.Employees.Include(e => e.Experiences).FirstOrDefault(e => e.EmployeeId == employeeId);
            if (employee == null)
            {
                return NotFound();
            }
            string jsonString = JsonConvert.SerializeObject(employee, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Content(jsonString, "application/json");
        }
        [HttpPost]
        public async Task<IActionResult> PostEmployee([FromForm] CommonDTO objCommon)
        {
            ImgUpload FileApi = new ImgUpload();
            FileApi.ImgName = GetImageFile(objCommon); 
            Employee empObj=new Employee();
            empObj.EmployeeName = objCommon.EmployeeName;
            empObj.IsActive=objCommon.IsActive;
            empObj.JoinDate = objCommon.JoinDate;
            empObj.ImageName = objCommon.ImageName;
            empObj.ImageUrl = FileApi.ImgName;
            _db.Employees.Add(empObj);
            await _db.SaveChangesAsync();
            var emp = _db.Employees.FirstOrDefault(e => e.EmployeeName == objCommon.EmployeeName);
            List<Experience> list = JsonConvert.DeserializeObject<List<Experience>>(objCommon.Experiences);
            if(list!=null && list.Count>0)
            {
                foreach(Experience ex in list)
                {
                    Experience expObj = new Experience
                    {
                        EmployeeId = emp.EmployeeId,
                        Title = ex.Title,
                        Duration = ex.Duration,
                    };
                    _db.Experiences.Add(expObj);
                }
                await _db.SaveChangesAsync();

            }
            return Ok("Employee Saved successfully");
        }

        private string GetImageFile(CommonDTO objCommon)
        {
            ImgUpload FileApi = new ImgUpload();
            string fileName = objCommon.ImageName + ".jpg";
            FileApi.ImgName = "\\Upload\\" + fileName;
            if (objCommon.ImgFile?.Length > 0)
            {
                if (!Directory.Exists(_environment.WebRootPath + "\\Upload"))
                {
                    Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                }
                string filePath = _environment.WebRootPath + "\\Upload\\" + fileName;
                using (FileStream fileStream = System.IO.File.Create(filePath))
                {
                    objCommon.ImgFile.CopyTo(fileStream);
                    fileStream.Flush();
                }
                FileApi.ImgName = "/Upload/" + fileName;
            }
            return FileApi.ImgName;
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> UpdareEmployee(int employeeId, [FromForm] CommonDTO objCommon)
        {
            var empObj = await _db.Employees.FindAsync(employeeId);
            if (empObj == null)
            {
                return NotFound("Employee not found");
            }

            ImgUpload FileApi = new ImgUpload();
            FileApi.ImgName = GetImageFile(objCommon);
            empObj.EmployeeName = objCommon.EmployeeName;
            empObj.IsActive = objCommon.IsActive;
            empObj.JoinDate = objCommon.JoinDate;
            empObj.ImageName = objCommon.ImageName;
            empObj.ImageUrl = FileApi.ImgName;
            
            var existingExperiences = _db.Experiences.Where(e => e.EmployeeId == employeeId);
            if(existingExperiences.Any())
            {
                _db.RemoveRange(existingExperiences); 
            }
            List<Experience> list = JsonConvert.DeserializeObject<List<Experience>>(objCommon.Experiences);
            if (list != null && list.Count > 0)
            {
                foreach (Experience ex in list)
                {
                    Experience expObj = new Experience
                    {
                        EmployeeId = employeeId,
                        Title = ex.Title,
                        Duration = ex.Duration,
                    };
                    _db.Experiences.Add(expObj);
                }   
            }
            await _db.SaveChangesAsync();
            return Ok("Employee updated successfully");
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult>DeleteEmployee(int employeeId)
        {
            var empObj = await _db.Employees.FindAsync(employeeId);
            if (empObj == null)
            {
                return NotFound("Employee not found");
            }
            _db.Employees.Remove(empObj);   
            await _db.SaveChangesAsync();
            return Ok("Employee Deleted successfully");
        }
    }

}

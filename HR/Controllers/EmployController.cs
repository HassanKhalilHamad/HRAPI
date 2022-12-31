using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HR.Data;
using HR.DBO;

namespace HR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployController : ControllerBase
    {
        private readonly DataContext _context;

        public EmployController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Employ>> AddEmploy(EmployDBO employ)
        {
            var emp = new Employ { Age= employ.Age, 
                BranchId = employ.BranchId,
                Name = employ.Name,
                Email = employ.Email,
                PhoneNumber=employ.PhoneNumber}; 
            _context.Employees.Add(emp);
             
            await _context.SaveChangesAsync();

            return Ok(employ);
        }

        [HttpGet]
        public async Task<ActionResult<List<Employ>>> GetAllEmployees()
        {
            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employ>> GetEmploy(int id)
        {
            var employ = await _context.Employees.FindAsync(id);
            if (employ == null)
            {
                return BadRequest("Branch not found");
            }
            return Ok(employ);
        }

        [HttpPut]
        public async Task<ActionResult<EmployDBO>> UpdateBranch(EmployDBO request)
        {
            var employ = await _context.Employees.FindAsync(request.EmployId);
            if (employ == null)
            {
                return BadRequest("Employ not found");
            }
            employ.Name = request.Name;
            employ.PhoneNumber = request.PhoneNumber;
            employ.Email = request.Email;
            employ.Age = request.Age;
            employ.BranchId = request.BranchId;


            await _context.SaveChangesAsync();
            return Ok(request);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employ>>> Delete(int id)
        {
            var employ = await _context.Employees.FindAsync(id);

            if (employ == null)
            {
                return BadRequest("Branch not found");
            }
            _context.Employees.Remove(employ);
            await _context.SaveChangesAsync();
            return Ok(await _context.Employees.ToListAsync());
        }
    }
}

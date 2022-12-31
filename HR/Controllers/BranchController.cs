using HR.Data;
using HR.DBO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly DataContext _context;

        public BranchController(DataContext context) 
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Branch>>> AddBranch(BranchDBO branch)
        {
            Branch obj = new Branch();
            obj.Street = branch.Street;
            obj.City = branch.City;
            obj.Country = branch.Country;
            obj.Area = branch.Area;
            obj.BuldingNum = branch.BuldingNum;
            obj.Name= branch.Name;
            _context.Branches.Add(obj);
            await _context.SaveChangesAsync();

            return Ok(await _context.Branches.ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult<List<Branch>>> GetAllBranches()
        {
            return Ok(await _context.Branches.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Branch>> GetBranch(int id)
        {
            var branch = await _context.Branches.FindAsync(id);
            if (branch == null)
            {
                return BadRequest("Branch not found");
            }
            return Ok(branch);
        }

        [HttpPut]
        public async Task<ActionResult<Branch>> UpdateBranch(BranchDBO request)
        {
            var branch = await _context.Branches.FindAsync(request.BranchId);
            if (branch == null)
            {
                return BadRequest("Branch not found");
            }
            branch.Name = request.Name;
            branch.Street = request.Street;
            branch.City = request.City;
            branch.Country = request.Country;
            branch.Area = request.Area;
            branch.BuldingNum= request.BuldingNum;

            await _context.SaveChangesAsync();
            return Ok(branch);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Branch>>> Delete(int id)
        {
            var branch = await _context.Branches.FindAsync(id);
            
            if (branch == null)
            {
                return BadRequest("Branch not found");
            }
           // var employees = _context.Employees.Where(e => e.Branch == branch);
           // _context.Employees.RemoveRange(employees);
            _context.Branches.Remove(branch);
            await _context.SaveChangesAsync();
            return Ok(await _context.Branches.ToListAsync());
        }
    }
}

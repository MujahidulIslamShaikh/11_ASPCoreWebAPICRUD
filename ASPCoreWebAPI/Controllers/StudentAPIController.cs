using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ASPCoreWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreWebAPI.Controllers
{
    [Route("api/[controller]")]  // attribute routing 
    [ApiController]  // attribute
    public class StudentAPIController : ControllerBase
    {
        private readonly CodeFirstDbContext codeFirstDbContext;

        public StudentAPIController(CodeFirstDbContext codeFirstDbContext)  // Create Constructor 
        {
            this.codeFirstDbContext = codeFirstDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents() // ye koi parameter accepter nahi karta
        {
            var data = await codeFirstDbContext.Students.ToListAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id) // ye parameter accept karta hai
        {
            var student = await codeFirstDbContext.Students.FindAsync(id);
            if (student == null) { return NotFound(); }
            return student;
        }
        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student std)
        {
            await codeFirstDbContext.Students.AddAsync(std);
            await codeFirstDbContext.SaveChangesAsync();
            return Ok(std);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student std)
        {
            if (id != std.Id) { return BadRequest(); }
            codeFirstDbContext.Entry(std).State = EntityState.Modified;
            await codeFirstDbContext.SaveChangesAsync();
            return Ok(std);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStduent(int id)
        {
            var std = await codeFirstDbContext.Students.FindAsync(id);
            if (std == null) { return NotFound(); }
            codeFirstDbContext.Students.Remove(std);
            await codeFirstDbContext.SaveChangesAsync();
            return Ok();
        }

    }
}

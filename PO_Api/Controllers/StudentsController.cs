using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PO_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        readonly ProjectOtchislenieDbContext _context;
        public StudentsController(ProjectOtchislenieDbContext context)
        {
            this._context = context;
        }

        [HttpGet("GetStudentById/{id}")]
        public async Task<Student> GetStudentById(int? id)
        {

            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            await Task.Delay(100);
            return student;
        }


        [HttpGet("GetStudents")]
        public async Task<List<Student>> GetStudents()
        {
            await Task.Delay(100);
            return new List<Student>(_context.Students.ToList());
        }

        [HttpPost("AddStudent")]
        public async Task<ActionResult> AddStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return Ok($"Добавлен новый студент - {student.Firstname} {student.Lastname}");
        }

        [HttpPut("EditStudent")]
        public async Task<ActionResult> EditStudent(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return Ok($"Студент обновлен - {student.Firstname} {student.Lastname}");
        }

        [HttpDelete("DeleteStudent")]
        public async Task<ActionResult> DeleteStudent(Student student)
        {
            var stu = _context.Students.FirstOrDefault(s => s.Id == student.Id);
            if (student.Id == stu.Id)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return Ok("Студенет");
            }
            else
                return BadRequest("Ошибка");
        }
    }
}

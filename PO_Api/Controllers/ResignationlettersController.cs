using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PO_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResignationlettersController : ControllerBase
    {
        readonly ProjectOtchislenieDbContext _context;
        public ResignationlettersController(ProjectOtchislenieDbContext context)
        {
            this._context = context;
        }

        [HttpGet("GetResignationletterById")]
        public async Task<Resignationletter> GetResignationletterById(int id)
        {
            await Task.Delay(100);
            var letter = _context.Resignationletters.FirstOrDefault(s => s.Id == id);
            if (letter == null)
            {
                return null;
            }
            Resignationletter getResignationletter = new Resignationletter()
            {
                Id = letter.Id,
                Reason = letter.Reason,
                Date = letter.Date,
                IdStudent = letter.IdStudent,
            };
            return getResignationletter;
        }

        [HttpGet("GetResignationletters")]
        public async Task<List<Resignationletter>> GetResignationletters()
        {
            await Task.Delay(100);
            return new List<Resignationletter>(_context.Resignationletters.ToList());
        }

        [HttpPost("AddResignationletter")]
        public async Task<ActionResult> AddResignationletter(ResignationletterModel resignationletter)
        {
            var letterNew = new Resignationletter { Date = resignationletter.Date, IdStudent = resignationletter.IdStudent, Reason = resignationletter.Reason };
            _context.Resignationletters.Add(letterNew);
            await _context.SaveChangesAsync();
            return Ok($"Добавлено новое заявление на отсичление - {resignationletter.Reason}  {resignationletter.Date}");
        }

        [HttpPut("EditResignationletter")]
        public async Task<ActionResult> EditResignationletter(ResignationletterModel resignationletter)
        {
            var letterNew = new Resignationletter { Date = resignationletter.Date, IdStudent = resignationletter.IdStudent, Reason = resignationletter.Reason };
            _context.Resignationletters.Update(letterNew);
            await _context.SaveChangesAsync();
            return Ok($"Заявление на отсичление обновлен - {resignationletter.Reason}  {resignationletter.Date}");
        }

        [HttpDelete("DeleteResignationletter/{id}")]
        public async Task<ActionResult> DeleteResignationletter(int id)
        {
            var letter = _context.Resignationletters.FirstOrDefault(s => s.Id == id);
            _context.Resignationletters.Remove(letter);
            await _context.SaveChangesAsync();
            return Ok("Заявнет");

        }
    }
}

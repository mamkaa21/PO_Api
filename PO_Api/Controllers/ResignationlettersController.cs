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

        [HttpPost("GetResignationletters")]
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


    }
}

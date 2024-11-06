using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PO_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly ProjectOtchislenieDbContext _context;
        public UsersController(ProjectOtchislenieDbContext context)
        {
            this._context = context;
        }

        [HttpPost("GetUsers")]
        public async Task<List<User>> GetUsers()
        {
            await Task.Delay(100);
            return new List<User>(_context.Users.ToList());
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult> AddUser (User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok($"Добавлен новый пользователь - {user.Login} {user.Password}");
        }

      
    }
}

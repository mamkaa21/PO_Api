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

        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            await Task.Delay(100);
            return Ok(_context.Users.ToList());
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult> AddUser (User user)
        {
            if (string.IsNullOrEmpty(user.Login))
                return BadRequest("Введите логин");
            var check = _context.Users.FirstOrDefault(s => s.Login == user.Login);
            if (check == null)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return Ok($"Добавлен новый пользователь - {user.Login} {user.Password}");
            }
            else
                return BadRequest("Такой пользователь уже существует");
        }

        [HttpPost("CheckLoginPassword")]
        public async Task<ActionResult<User>> CheckLoginPassword (User user)
        {
            if (string.IsNullOrEmpty(user.Login) || string.IsNullOrEmpty(user.Password))
                return BadRequest("Введите логин и пароль");
            var check = _context.Users.FirstOrDefault(s => s.Login == user.Login && s.Password == user.Password);
            if (check == null)
                return NotFound("Такой не найден");
            else
                return Ok(check);
        }


    }
}

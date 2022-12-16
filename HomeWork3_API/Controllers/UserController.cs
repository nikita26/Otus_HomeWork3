using Microsoft.AspNetCore.Mvc;
using Services.Abstractons;
using Services.Contracts;
using Services.Implementations;

namespace HomeWork3_API.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _service;

        public UserController(IUserService service, ILogger<UserController> logger)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Получить всех пользователей из БД
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAll")]
        public IEnumerable<UserDto> GetAllUsers()
        {
            return _service.GetAll();
        }

        /// <summary>
        /// Получить пользователя по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get")]
        public IActionResult GetUserById(int id)
        {
            var findedUser = _service.GetById(id);
            if(findedUser == null)
                return NotFound();
            return Ok(findedUser);
        }

        /// <summary>
        /// Попытка сохранить нового пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public IActionResult CreateUser(UserDto user)
        {
            var findItem = _service.FindUser(user.Id, user.Login);
            if (findItem == null)
                return Ok(_service.Create(user));
            return StatusCode(409, "Пользователь с таким Id или логином уже существует в базе");
        }
    }
}
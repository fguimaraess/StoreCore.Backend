using Store.DAL;
using Store.DAL.Context;
using Store.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly StoreContext _context;
        public UserController(StoreContext context)
        {
            _context = context;
        }

        [Route("user/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetByID(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [Route("user/all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = _context.Users.ToList();

            if (users.Count() == 0)
                return NotFound();

            return Ok(users);
        }

        [Route("user")]
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] User user)
        {
            _context.Users.Add(new User { Login = user.Login, Password = user.Password, Token = user.Token });
            var clientSaved =_context.SaveChanges();

            if (Convert.ToBoolean(clientSaved))
                user.Id = _context.Users.Last().Id;

            return Ok(user);
        }

        [Route("user/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {

            var user = _context.Users.Find(id);

            if (user == null)
                return NotFound();
            _context.Users.Remove(user);
            _context.SaveChanges();

            return Ok();
        }
    }
}
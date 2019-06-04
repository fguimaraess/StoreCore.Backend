using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace storecore.backend.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly StoreContext _context;
        public ClientController(StoreContext context)
        {
            _context = context;

        }

        [Route("client/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetClient(int id)
        {
            var client = _context.Clients.Find(id);

            if (client == null)
                return NotFound();

            return Ok(client);
        }

        // Add a department to db.
        [Route("client")]
        [HttpPost]
        public async Task<IActionResult> AddClient([FromBody] Client client)
        {
            _context.Clients.Add(new Client { Name = client.Name, BirthDate = client.BirthDate, Email = client.Email });
            var clientSaved =_context.SaveChanges();

            if (Convert.ToBoolean(clientSaved))
                client.Id = _context.Clients.Last().Id;

            return Ok(client);
        }
    }
}
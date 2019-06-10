using Microsoft.AspNetCore.Mvc;
using Store.DAL.Context;
using Store.DAL.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Controllers
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

        [Route("client/all")]
        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = _context.Clients.ToList();

            if (clients.Count() == 0)
                return NotFound();

            return Ok(clients);
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

        [Route("client/{id}")]
        [HttpDelete]
        public async Task<IActionResult> RemoveClient(int id)
        {

            var client = _context.Clients.Find(id);

            if (client == null)
                return NotFound();
            _context.Clients.Remove(client);
            _context.SaveChanges();

            return Ok();
        }
    }
}
using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace storecore.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : InjectedController
    {
        public ClientController(StoreContext context) : base(context) { }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var department = await db.Clients.FindAsync(id);
            if (department == default(Client))
            {
                return NotFound();
            }
            return Ok(department);
        }

        // Add a department to db.
        [HttpPost]
        public async Task<IActionResult> AddClient([FromBody] Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await db.AddAsync(client);
            await db.SaveChangesAsync();
            return Ok(client.Id);
        }
    }

    public class InjectedController : ControllerBase
    {
        protected readonly StoreContext db;

        public InjectedController(StoreContext context)
        {
            db = context;
        }
    }
}
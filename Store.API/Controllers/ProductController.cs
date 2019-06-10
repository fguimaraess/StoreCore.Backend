using Store.DAL;
using Store.DAL.Context;
using Store.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductController(StoreContext context)
        {
            _context = context;
        }

        [Route("product/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetByID(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [Route("product/all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = _context.Products.ToList();

            if (products.Count() == 0)
                return NotFound();

            return Ok(products);
        }

        [Route("product")]
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Product product)
        {
            _context.Products.Add(new Product { Name = product.Name, Price = product.Price, Description = product.Description, Image = product.Image });
            var productSaved =_context.SaveChanges();

            if (Convert.ToBoolean(productSaved))
                product.Id = _context.Products.Last().Id;

            return Ok(product);
        }

        private byte[] GenarateImage()
        {
            System.Collections.Generic.IEnumerable<int> values = Guid.NewGuid().ToByteArray().Select(x => (int)x);
            int red = values.Take(5).Sum() % 255;
            int green = values.Skip(5).Take(5).Sum() % 255;
            int blue = values.Skip(10).Take(5).Sum() % 255;

            var color = Color.FromArgb(255, red, green, blue);

            byte r = color.R;
            byte g = color.G;
            byte b = color.B;

            return new byte[] { r, g, b };
        }

        [Route("product/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {

            var product = _context.Products.Find(id);

            if (product == null)
                return NotFound();
            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok();
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShopAPI.Models;

namespace MyShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase // api controller. products controller inherited from controller base
    {
        private readonly MYDBAPIContext _context; 

        public ProductsController(MYDBAPIContext context) // create constructor to load data to parameter
        {
            _context = context;
        }


        //public ProductsController(MYDBAPIContext context)
        //{
        //    _context = context;
        //}
        [HttpGet]
        public async Task <List<ProductDb>> Get() // to get the value of a database as a list
        {
            return await _context.ProductDbs.ToListAsync();
                              
        }
        [HttpGet("{id}")]   // use id as a paramter to check conditions.
        public async Task <ActionResult> Get(int id)
        {
            var product = await _context.ProductDbs.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult> Post(ProductDb productdata)
        {
            _context.Add(productdata);
            await _context.SaveChangesAsync();
            return Ok(productdata);
        }

        [HttpPut]

        public async Task<ActionResult> Put(ProductDb product)
        { 

            if (product == null || product.Id == 0)
                return BadRequest(); 
            var products = await _context.ProductDbs.FindAsync(product.Id);
            if (products == null)
                return NotFound();
            products.Id = product.Id;
            products.Name = product.Name;
            products.Description = product.Description; products.Price = product.Price;
            await _context.SaveChangesAsync();
            return Ok();

    }

    [HttpDelete("{id}")]

        public async Task <ActionResult> Delete(int id)
        {
            var product  = await _context.ProductDbs.FindAsync(id);
            if (product == null)
                return NotFound();
            _context.ProductDbs.Remove(product);
            await _context.SaveChangesAsync(); 
            return Ok();
        }
    }
}

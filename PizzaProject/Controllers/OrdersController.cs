using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaProject.Models;

namespace PizzaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private s14893Context _context;
        public OrdersController(s14893Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(_context.Orders.ToList());
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOrder(int id)
        {
            var order = _context.Orders.FirstOrDefault(e => e.IdOrder == id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
    }
}
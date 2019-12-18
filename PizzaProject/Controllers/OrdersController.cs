using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost]
        public IActionResult Create(Orders newOrder)
        {
            _context.Add(newOrder);
            _context.SaveChanges();
            //201
            return StatusCode(201, newOrder); //201, 202
        }
        [HttpPut]
        public IActionResult Update(Orders updatedOrder)
        {
            if (_context.Orders.Count(e => e.IdOrder == updatedOrder.IdOrder) == 0)
            {
                return NotFound();
            }

            _context.Orders.Attach(updatedOrder);
            _context.Entry(updatedOrder).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedOrder);
        }
        [HttpDelete("{IdOrder:int}")]
        public IActionResult Delete(int IdOrder)
        {
            var order = _context.Orders.FirstOrDefault(e => e.IdOrder == IdOrder);
            if (order == null)
            {
                return NotFound();
            }
            _context.Orders.Remove(order);
            _context.SaveChanges();

            return Ok(order);
        }
    }
}
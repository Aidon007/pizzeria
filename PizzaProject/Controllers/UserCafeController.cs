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
    public class UserCafeController : ControllerBase
    {
        private s14893Context _context;
        public UserCafeController(s14893Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_context.UserCafe.ToList());
        }
        [HttpGet("{id:int}")]
        public IActionResult GetUser(int id)
        {
            var order = _context.UserCafe.FirstOrDefault(e => e.IdUser == id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
    }
}
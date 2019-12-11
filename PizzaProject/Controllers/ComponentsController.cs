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
    public class ComponentsController : ControllerBase
    {
        private s14893Context _context;
        public ComponentsController(s14893Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetComponents()
        {
            return Ok(_context.Components.ToList());
        }
        [HttpGet("{id:int}")]
        public IActionResult GetComponent(int id)
        {
            var component = _context.Components.FirstOrDefault(e => e.IdComponent == id);
            if (component == null)
            {
                return NotFound();
            }
            return Ok(component);
        }
    }
}
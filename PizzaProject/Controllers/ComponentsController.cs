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
    public class ComponentsController : ControllerBase
    {
        private s14893Context _context;
        public ComponentsController(s14893Context context)
        {
            _context = context;
        }

        /// - przed metodą
        // Swashbuckle.AspNetCore - biblioteka

        //int wiek = 10;
        //var cos=$"Ala {wiek} m kota";     to samo co      String.format("");
        //


        /// <summary>
        /// Metoda zwraca komponenty
        /// </summary>
        /// <returns>
        /// Lista objektow reprezentująca komponenty
        /// </returns>
        /// OpenAPI
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

        [HttpPost]
        public IActionResult Create(Components newComponent)
        {
            _context.Add(newComponent);
            _context.SaveChanges();
            //201
            return StatusCode(201, newComponent ); //201, 202
        }
        [HttpPut]
        public IActionResult Update(Components updatedComponent)
        {
            if(_context.Components.Count(e => e.IdComponent == updatedComponent.IdComponent) == 0)
            {
                return NotFound();
            }

            _context.Components.Attach(updatedComponent);
            _context.Entry(updatedComponent).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedComponent);
        }
        [HttpDelete("{IdComponent:int}")]
        public IActionResult Delete(int idComponent)
        {
            var component = _context.Components.FirstOrDefault(e => e.IdComponent == idComponent);
            if(component == null)
            {
                return NotFound();
            }
            _context.Components.Remove(component);
            _context.SaveChanges();

            return Ok(component);
        }
    }
}
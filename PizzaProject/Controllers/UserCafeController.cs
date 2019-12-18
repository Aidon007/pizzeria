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

        [HttpPost]
        public IActionResult Create(UserCafe newUserCafe)
        {
            _context.Add(newUserCafe);
            _context.SaveChanges();
            //201
            return StatusCode(202, newUserCafe); //201, 202
        }
        [HttpPut]
        public IActionResult Update(UserCafe updatedUserCafe)
        {
            if (_context.UserCafe.Count(e => e.IdUser == updatedUserCafe.IdUser) == 0)
            {
                return NotFound();
            }

            _context.UserCafe.Attach(updatedUserCafe);
            _context.Entry(updatedUserCafe).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedUserCafe);
        }
        [HttpDelete("{IdUser:int}")]
        public IActionResult Delete(int IdUser)
        {
            var user = _context.UserCafe.FirstOrDefault(e => e.IdUser == IdUser);
            if (user == null)
            {
                return NotFound();
            }
            _context.UserCafe.Remove(user);
            _context.SaveChanges();

            return Ok(user);
        }
    }
}
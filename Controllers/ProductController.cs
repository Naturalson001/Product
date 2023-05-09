using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Product.product;

namespace Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private UserService _service;
        public ProductController(UserService service)
        {
          this._service = service ?? throw new ArgumentNullException(nameof(UserService)) ;

        }


        // GET: api/Product
        [HttpGet]
        public IActionResult Get()
        {
            
                var allUsers = _service.getAllUser();
                return Ok(allUsers);
            
        }

        // GET: api/Product/5
        [HttpGet("Identifiyer")]
        public ActionResult<User> GetUser(int UserId, string Email)
        {
            var user = _service.getUserById(UserId)??
                _service.getUserByEmail(Email) ;
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

      

        // POST: api/Product
        [HttpPost("AddUser")]
        public IActionResult createUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            _service.createUser(user);
            return Ok();
        }

        // PUT: api/Product/5
        [HttpPut("{identifier}")]
        public IActionResult UpdateUser(int UserId, [FromBody] User user , string Email)
        {
            if (user == null)
            {
                return BadRequest();
            }
            _service.UpdateUser(UserId, user, Email);
            return Ok(user);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int UserId)
        {
            var existingUser = _service.getUserById(UserId);
            if (existingUser == null)
            {
                return NotFound();
            }
            _service.delectUser(UserId);
            return Ok();
        }
    }
}

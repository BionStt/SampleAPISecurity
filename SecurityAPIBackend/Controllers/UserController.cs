using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurityAPIBackend.Models;
using SecurityAPIBackend.Services;

namespace SecurityAPIBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUser _usr;
        public UserController(IUser usr)
        {
            _usr = usr;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]User usr)
        {
            await _usr.Register(usr);
            return Ok();
        }

        [HttpPost("createrole")]
        public async Task<IActionResult> CreateRole([FromBody]string roleName)
        {
            await _usr.CreateRole(roleName);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("addusertorole")]
        public async Task<IActionResult> AddUserToRole([FromBody] UserRole usrRole)
        {
            await _usr.AddUserToRole(usrRole.username, usrRole.rolename);
            return Ok();
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]User userParam)
        {
            var user = await _usr.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

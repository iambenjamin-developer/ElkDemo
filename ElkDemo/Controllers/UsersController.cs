using ElkDemo.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElkDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        [HttpGet("{id}")]
        public User Get(string id)
        {
            return new User();
        }


        [HttpPost]
        public void Post([FromBody] User value)
        {
        }


    }
}

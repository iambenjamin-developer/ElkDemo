using ElkDemo.Entities;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System.Linq;
using System.Threading.Tasks;

namespace ElkDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IElasticClient _elasticClient;

        public UsersController(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        [HttpGet("{id}")]
        public async Task<User> Get(string id)
        {

            var response = await _elasticClient.SearchAsync<User>(s => s
                            .Index("users")
                            .Query(q => q.Match(m => m.Field(f => f.Name).Query(id))));

            return response?.Documents?.FirstOrDefault();
        }


        [HttpPost]
        public void Post([FromBody] User value)
        {
        }


    }
}

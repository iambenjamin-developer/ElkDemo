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
            /*

            var response = await _elasticClient.SearchAsync<User>(s => s
                            .Index("users")
                            .Query(q => q.Match(m => m.Field(f => f.Name).Query(id))));

            return response?.Documents?.FirstOrDefault();
            */

            var response = await _elasticClient.GetAsync<User>(new DocumentPath<User>(
                new Id(id)), x => x.Index("users"));

            return response?.Source;
        }


        [HttpPost]
        public async Task<string> Post([FromBody] User value)
        {
            var response = await _elasticClient.IndexAsync<User>(value, x => x.Index("users"));

            return response.Id;
        }


    }
}

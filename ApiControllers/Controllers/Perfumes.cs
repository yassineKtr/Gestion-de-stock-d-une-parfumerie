using Microsoft.AspNetCore.Mvc;



namespace ApiControllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Perfumes : ControllerBase
    {
        private readonly IPerfumeRepository repo;
        // GET: api/<Parfumerie>
        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
                return Results.Ok(await repo.GetPerfumes());
            }
            catch(Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        // GET api/<Parfumerie>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(Guid id)
        {
            try
            {
               var results = await repo.GetPerfume(id);
               if (results == null) return Results.NotFound();
               return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        // POST api/<Parfumerie>
        [HttpPost]
        public async Task<IResult> Post([FromBody] Perfume perfume)
        {
            //Fix repo == null 32
            try
            {
               await repo.AddPerfume(perfume);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        // PUT api/<Parfumerie>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Parfumerie>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

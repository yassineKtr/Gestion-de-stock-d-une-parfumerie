using Microsoft.AspNetCore.Mvc;
using ParfumerieServices.Repositories;


namespace ApiControllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Perfumes : ControllerBase
    {
        private readonly IPerfumeServices _repo;
        public Perfumes(IPerfumeServices repo)
        {
            _repo = repo;   
        }
        // GET: api/<Parfumerie>
        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
                return Results.Ok(await _repo.GetAllPerfumes());
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
               var results = await _repo.GetPerfume(id);
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
            
            try
            {
               await _repo.AddPerfume(perfume);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        // PUT api/<Parfumerie>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(Guid id, [FromBody] Perfume perfume)
        {
            try
            {
                await _repo.UpdatePerfume(perfume);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        // DELETE api/<Parfumerie>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(Guid id,[FromBody] Perfume perfume)
        {
            try
            {
                await _repo.RemovePerfume(perfume);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        
        [HttpGet("brand/{brand}")]
        public async Task<IResult> GetPerfumesByBrand(string brand)
        {

            try
            {
                var results = await _repo.GetPerfumesByBrand(brand);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpGet("brand/")]
        public async Task<IResult> GetBrands()
        {
            try
            {
                return Results.Ok(await _repo.GetAllBrands());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        [HttpPut("promo/{perfumeId}/{amount}")]
        public async Task<IResult> AddPromoToPerfume(Guid perfumeId,double amount)
        {
            try
            {
                await _repo.AddPromo(perfumeId,amount);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}

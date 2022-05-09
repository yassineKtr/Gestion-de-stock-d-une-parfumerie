using Microsoft.AspNetCore.Mvc;

namespace ApiControllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Perfumes : ControllerBase
    {
        private readonly IReadPerfume _reader;
        private readonly IWritePerfume _writer;
        public Perfumes(IReadPerfume reader, IWritePerfume writer)
        {
            _reader = reader;
            _writer = writer;
        }
        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
                return Results.Ok(await _reader.GetPerfumes());
            }
            catch(Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IResult> Get(Guid id)
        {
            try
            {
               var results = await _reader.GetPerfume(id);
               if (results == null) return Results.NotFound();
               return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IResult> Post([FromBody] Perfume perfume)
        {
            
            try
            {
               await _writer.AddPerfume(perfume);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IResult> Put(Guid id, [FromBody] Perfume perfume)
        {
            try
            {
                await _writer.UpdatePerfume(perfume);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(Guid id)
        {
            try
            {
                await _writer.DeletePerfume(id);
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
                var results = await _reader.GetPerfumesByBrand(brand);
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
                return Results.Ok(await _reader.GetAllBrands());
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
                await _writer.AddPromo(perfumeId,amount);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}

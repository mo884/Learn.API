using Learn.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Learn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ApplicationContext Db;
        public GenresController(ApplicationContext Db)
        {
            this.Db = Db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await Db.Genres.ToListAsync();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Genre genre)
        {
            var data = await Db.Genres.AddAsync(genre);
            await Db.SaveChangesAsync();
            return Ok(data);

        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Genre genre)
        {
            var data = await Db.Genres.Where(a=> a.Id==id).SingleOrDefaultAsync();
            if (data == null)
                return NotFound();
            data.Name  = genre.Name;
            await Db.SaveChangesAsync();
            return Ok(data);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteAsync(int id)
        {

            var data = await Db.Genres.Where(a => a.Id == id).SingleOrDefaultAsync();
            if (data == null)
                return NotFound();
            Db.Genres.Remove(data);
            await Db.SaveChangesAsync();
            return Ok(data);

        }
    }
}

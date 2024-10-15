using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VietKoiShow.ModelMapper;
using VietKoiShow.Repositories;

namespace VietKoiShow.Controllers
{
//dong nay duoc chinh sua luc 4:26 - 10/15/2024
//dong nay duoc chinh sua luc 4:38 - 10/15/2024
    [Route("api/[controller]")]
    [ApiController]
    public class KoiFishController : ControllerBase
    {
        private readonly IKoiFishRepository _koiFishRepo;

        public KoiFishController(IKoiFishRepository repo)
        {
            _koiFishRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFishes()
        {
            try
            {
                return Ok(await _koiFishRepo.GetAllFishsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFishById(string id)
        {
            var fish = await _koiFishRepo.GetFishAsync(id);
            return fish == null ? NotFound() : Ok(fish);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewFish(KoiFishModel model)
        {
            try
            {
                var newFishId = await _koiFishRepo.AddFishAsync(model);
                var fish = await _koiFishRepo.GetFishAsync(newFishId);
                return fish == null ? NotFound() : Ok(fish);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFish(string id, [FromBody] KoiFishModel model)
        {
            if (id != model.KoiId)
            {
                return NotFound();
            }
            await _koiFishRepo.UpdateFishAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFish([FromRoute] string id)
        {
            await _koiFishRepo.DeleteFishAsync(id);
            return Ok();
        }
    }
}

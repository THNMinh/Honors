using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VietKoiShow.ModelMapper;
using VietKoiShow.Models;

namespace VietKoiShow.Repositories
{
    public class KoiFishRepository : IKoiFishRepository
    {
        private readonly VietKoiExpoContext _context;
        private readonly IMapper _mapper;

        public KoiFishRepository(VietKoiExpoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddFishAsync(KoiFishModel model)
        {
            var newFish = _mapper.Map<TblkoiFish>(model);
            _context.TblkoiFishes!.Add(newFish);
            await _context.SaveChangesAsync();

            return newFish.KoiId;
        }

        public async Task DeleteFishAsync(string id)
        {
            var deleteFish = _context.TblkoiFishes!.SingleOrDefault(b => b.KoiId == id);
            if (deleteFish != null)
            {
                _context.TblkoiFishes!.Remove(deleteFish);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<KoiFishModel>> GetAllFishsAsync()
        {
            var koiFishes = await _context.TblkoiFishes!.ToListAsync();
            return _mapper.Map<List<KoiFishModel>>(koiFishes);
        }

        public async Task<KoiFishModel> GetFishAsync(string id)
        {
            var koiFish = await _context.TblkoiFishes!.FindAsync(id);
            return _mapper.Map<KoiFishModel>(koiFish);
        }

        public async Task UpdateFishAsync(string id, KoiFishModel model)
        {
            if (id == model.KoiId)
            {
                var updateFish = _mapper.Map<TblkoiFish>(model);
                _context.TblkoiFishes!.Update(updateFish);
                await _context.SaveChangesAsync();
            }
        }
    }
}

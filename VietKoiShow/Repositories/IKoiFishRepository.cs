using VietKoiShow.ModelMapper;

namespace VietKoiShow.Repositories
{
    public interface IKoiFishRepository
    {
        public Task<List<KoiFishModel>> GetAllFishsAsync();
        public Task<KoiFishModel> GetFishAsync(string id);
        public Task<string> AddFishAsync(KoiFishModel model);
        public Task UpdateFishAsync(string id, KoiFishModel model);
        public Task DeleteFishAsync(string id); 
    }
}

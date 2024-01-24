using CinemaApp.Repository;

namespace CinemaApp.Services
{
    public class BillboardService
    {
        private readonly BillboardRepository _billboardRepository;
    
        public BillboardService(BillboardRepository billboardRepository)
        {
            _billboardRepository = billboardRepository;
        }

        public async Task cancelBillboardById(int billboardId)
        {
            await _billboardRepository.CancelBillboardById(billboardId);
        }
    }
}

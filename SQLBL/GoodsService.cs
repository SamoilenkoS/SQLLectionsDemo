using SQLDAL.Models;
using SQLDAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLBL
{
    public class GoodsService : IGoodsService
    {
        private readonly IGoodsRepository _goodsRepository;

        public GoodsService(IGoodsRepository goodsRepository)
        {
            _goodsRepository = goodsRepository;
        }

        public async Task<IEnumerable<GoodCount>> GetTotalGoodCountsAsync()
            => await _goodsRepository.GetTotalGoodCountsAsync();

        public async Task AddGoodsToWarehouse(GoodsWarehouse goodsWarehouse)
            => await _goodsRepository.AddGoodsToWarehouse(goodsWarehouse);
    }
}

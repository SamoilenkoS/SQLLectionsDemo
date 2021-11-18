using Microsoft.EntityFrameworkCore;
using SQLDAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLDAL.Repositories
{
    public class GoodsRepository : IGoodsRepository
    {
        private readonly EFCoreContext _dbContext;

        public GoodsRepository(EFCoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<GoodCount>> GetTotalGoodCountsAsync()
            => await _dbContext.TotalGoodsCount.ToListAsync();

        public async Task AddGoodsToWarehouse(GoodsWarehouse goodsWarehouses)
        {
            await _dbContext.Database.ExecuteSqlRawAsync(
                "AddGoodsToWarehouse @p0, @p1, @p2",
                    goodsWarehouses.GoodId,
                    goodsWarehouses.WarehouseId,
                    goodsWarehouses.Count);
        }
     }
}

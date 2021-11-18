using SQLDAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLDAL.Repositories
{
    public interface IGoodsRepository
    {
        Task<IEnumerable<GoodCount>> GetTotalGoodCountsAsync();
        Task AddGoodsToWarehouse(GoodsWarehouse goodsWarehouses);
    }
}

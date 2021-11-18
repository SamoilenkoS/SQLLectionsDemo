using SQLDAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLBL
{
    public interface IGoodsService
    {
        Task<IEnumerable<GoodCount>> GetTotalGoodCountsAsync();
        Task AddGoodsToWarehouse(GoodsWarehouse goodsWarehouse);
    }
}

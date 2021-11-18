using System;

namespace SQLDAL.Models
{
    public class GoodsWarehouse
    {
        public Guid GoodId { get; set; }
        public Guid WarehouseId { get; set; }
        public int Count { get; set; }
        public Warehouse Warehouse { get; set; }
        public Good Good { get; set; }
    }
}

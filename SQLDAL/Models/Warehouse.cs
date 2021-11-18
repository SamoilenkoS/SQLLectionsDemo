using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SQLDAL.Models
{
    public class Warehouse
    {
        [Key]
        public Guid Id { get; set; }
        public string Address { get; set; }
        public List<GoodsWarehouse> GoodsWarehouses { get; set; }
    }
}

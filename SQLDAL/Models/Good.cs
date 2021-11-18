using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SQLDAL.Models
{
    public class Good
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<GoodsWarehouse> GoodsWarehouses { get; set; }
    }
}
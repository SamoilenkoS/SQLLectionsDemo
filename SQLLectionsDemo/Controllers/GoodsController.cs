using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SQLBL;
using SQLDAL.Models;
using System.Threading.Tasks;

namespace SQLLectionsDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoodsController : ControllerBase
    {
        private readonly IGoodsService _goodsService;
        private readonly ILogger<GoodsController> _logger;

        public GoodsController(
            IGoodsService goodsService,
            ILogger<GoodsController> logger)
        {
            _goodsService = goodsService;
            _logger = logger;
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetGoodsCountAsync()
        {
            return Ok(await _goodsService.GetTotalGoodCountsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddGoodsToWarehouse(GoodsWarehouse goodsWarehouse)
        {
            await _goodsService.AddGoodsToWarehouse(goodsWarehouse);

            return Ok();
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.CodeAnalysis;

namespace SQLDAL.Migrations
{
    public class TotalGoodCountView : Migration
    {
        protected override void Up([NotNull] MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW TotalGoodCount AS
                SELECT g.Id,
                   g.Title,
                    Sum(gw.[Count]) AS Count
                FROM GoodsWarehouses gw
                INNER JOIN Goods g
                    ON g.Id = gw.GoodId
                INNER JOIN Warehouses w
                    ON gw.WarehouseId = w.Id
                GROUP BY g.[Id],
                    g.[Title],
                    gw.[GoodId];");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop view TotalGoodCount;");
        }
    }
}

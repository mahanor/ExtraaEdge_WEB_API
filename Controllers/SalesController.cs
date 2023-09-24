using ExtraaEdge_WEB_API.DataContext;
using ExtraaEdge_WEB_API.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExtraaEdge_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SalesController : ControllerBase
    {
        private readonly ISalesServices _salesServices;
        private readonly CollectionContext _ctx;
        public SalesController(ISalesServices salesServices, CollectionContext ctx)
        {
            _salesServices = salesServices;
            _ctx = ctx;
        }


        [HttpGet("monthly-sales")]
        public IActionResult GetMonthlySalesReport(DateTime fromDate, DateTime toDate)
        {
            var Sales = _salesServices.GetSalesByDateRange(fromDate, toDate);
            return Ok(Sales);

        }

        [HttpGet("monthly-profit")]
        public IActionResult GetMonthlyProfitReport(DateTime fromDate, DateTime toDate)
        {
            var TotalProfit = _salesServices.GetTotalProfitByDateRange(fromDate, toDate);

            var TotalProfits = new
            {
                TotalProfits = TotalProfit
            };


            return Ok(TotalProfits);

        }

        [HttpGet("monthly-loss")]
        public IActionResult GetMonthlyLossReport(DateTime fromDate, DateTime toDate)
        {

            var TotalLosss = _salesServices.GetTotalLossByDateRange(fromDate, toDate);


            return Ok(TotalLosss);

        }


        [HttpGet("monthly-brand-wise-sales")]
        public IActionResult GetMonthlyBrandWiseSalesReport(DateTime fromDate, DateTime toDate, int page, int pageSize)
        {

            var totalRecord = _ctx.brands
                .SelectMany(brand => brand.Mobiles)
                .SelectMany(moblile => moblile.Sales)
                .Count(s => s.SaleDate >= fromDate && s.SaleDate <= toDate);

            var brandWiseSalesReport = _ctx.brands.ToList()
                //.Include(b => b.Mobiles)
                .Select(brand => new
                {
                    BrandName = brand.BrandName,
                    TotalSales = brand.Mobiles
                        .SelectMany(m => m.Sales)
                        .Where(s => s.SaleDate >= fromDate && s.SaleDate <= toDate)
                        .Sum(s => s.SaleAmount)
                }).OrderByDescending(b => b.TotalSales)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();


            var response = new
            {
                page = page,
                pageSize = pageSize,
                totalRecord = totalRecord,
                brandWiseSalesReport = brandWiseSalesReport,

            };

            return Ok(response);

        }


    }
}

using ExtraaEdge_WEB_API.Model;

namespace ExtraaEdge_WEB_API.Services.IServices
{
    public interface ISalesServices
    {
        List<Sale> GetSalesByDateRange(DateTime fromDate, DateTime toDate);
        decimal GetTotalProfitByDateRange(DateTime fromDate, DateTime toDate);
        decimal GetTotalLossByDateRange(DateTime fromDate, DateTime toDate);
        List<Sale> GetBrandWiseSalesReport(DateTime fromDate, DateTime toDate, int page, int pageSize);
    }
}

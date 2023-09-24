using ExtraaEdge_WEB_API.DataContext;
using ExtraaEdge_WEB_API.Model;
using ExtraaEdge_WEB_API.Repository.IRepository;
using ExtraaEdge_WEB_API.Services.IServices;

namespace ExtraaEdge_WEB_API.Services.SevicesImpl
{
    public class SalesServiceImpl : ISalesServices
    {
        private readonly CollectionContext _context;
        private readonly IRepository _IRepo;

        public SalesServiceImpl(CollectionContext context,IRepository IRepo)
        {
            _context = context;
            _IRepo = IRepo;
        }

        public List<Sale> GetSalesByDateRange(DateTime fromDate, DateTime toDate)
        {
            var sales = _IRepo.GetSalesByDateRange(fromDate, toDate);

            return sales;
        }

        public decimal GetTotalProfitByDateRange(DateTime fromDate, DateTime toDate)
        {
            var TotalProfit = _IRepo.GetTotalProfitByDateRange(fromDate, toDate);

            return TotalProfit;
        }

        public decimal GetTotalLossByDateRange(DateTime fromDate, DateTime toDate)
        {
            var TotalLoss = _IRepo.GetTotalLossByDateRange(fromDate, toDate);
         
            return TotalLoss;
        }

        public List<Sale> GetBrandWiseSalesReport(DateTime fromDate, DateTime toDate, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        /*public List<BrandSalesReport> GetBrandWiseSalesReport(DateTime fromDate, DateTime toDate, int page, int pageSize)
        {
            throw new NotImplementedException();
        }
*/
        /*   public List<Sale> GetBrandWiseSalesReport(DateTime fromDate, DateTime toDate, int page, int pageSize)
           {
               // Implement this method as per your requirements
               // Include sorting, paging, and reporting logic here

               return Ok();

           }*/

    }
}

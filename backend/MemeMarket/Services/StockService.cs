using System.Linq;
using System.Threading.Tasks;
using MemeMarket.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MemeMarket.Services
{
    public class StockService : IStockService
    {
        private readonly ILogger<StockService> logger;
        private readonly MarketContext context;

        public StockService(
            ILogger<StockService> logger,
            MarketContext context
        )
        {
            this.logger = logger;
            this.context = context;
        }

        public async Task<int> GetStockId(string stockSymbol)
        {
            return await this.context.Stocks
                .Where(s => s.Symbol == stockSymbol)
                .Select(s => s.StockId)
                .FirstOrDefaultAsync();
        }
    }
}

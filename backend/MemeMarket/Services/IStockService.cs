using System.Threading.Tasks;

namespace MemeMarket.Services
{
    public interface IStockService
    {
        Task<int> GetStockId(string stockSymbol);
    }
}

using System.Threading.Tasks;
using TRMDataManager.Library.Models;

namespace TRMDesktopUI.Library.Api
{
    public interface ISaleEndpoint
    {
        Task PostSale(SaleModel sale);
    }
}
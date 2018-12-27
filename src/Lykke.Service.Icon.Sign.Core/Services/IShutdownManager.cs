using System.Threading.Tasks;

namespace Lykke.Service.Icon.Sign.Core.Services
{
    public interface IShutdownManager
    {
        Task StopAsync();
    }
}

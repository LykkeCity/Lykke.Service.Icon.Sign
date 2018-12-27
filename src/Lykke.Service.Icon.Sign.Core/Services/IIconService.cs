using Lykke.Service.Icon.Sign.Core.Domain.Icon;

namespace Lykke.Service.Icon.Sign.Core.Services
{
    public interface IIconSignService
    {
        KeyPair GenerateKeyPair();

        string SignTransaction(string privateKey, string serializedTransaction);
    }
}

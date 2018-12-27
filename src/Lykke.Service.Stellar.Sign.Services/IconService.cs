using JetBrains.Annotations;
using Lykke.Icon.Sdk;
using Lykke.Icon.Sdk.Data;
using Lykke.Service.Icon.Sign.Core.Domain.Icon;
using Lykke.Service.Icon.Sign.Core.Services;
using System;
using System.Linq;

namespace Lykke.Service.Icon.Sign.Services
{
    public class IconSignService : IIconSignService
    {
        [UsedImplicitly]
        public IconSignService()
        {
        }

        public KeyPair GenerateKeyPair()
        {
            var wallet = Lykke.Icon.Sdk.KeyWallet.Create();

            return new KeyPair
            {
                PrivateKey = wallet.GetPrivateKey().ToHexString(false),
                Address = wallet.GetAddress().ToString()
            };
        }

        public string SignTransaction(string privateKey, string serializedTransaction)
        {
            var pkBytes = new Bytes(privateKey);
            var wallet = Lykke.Icon.Sdk.KeyWallet.Load(pkBytes);
            var transaction = TransactionDeserializer.Deserialize(serializedTransaction);
            var signedTr = new SignedTransaction(transaction, wallet);
            var props = signedTr.GetProperties();

            return SignedTransaction.Serialize(props);
        }
    }
}

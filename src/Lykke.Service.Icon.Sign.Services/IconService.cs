using JetBrains.Annotations;
using Lykke.Icon.Sdk;
using Lykke.Icon.Sdk.Data;
using Lykke.Service.Icon.Sign.Core.Domain.Icon;
using Lykke.Service.Icon.Sign.Core.Services;
using System;
using System.Linq;
using Lykke.Service.Icon.Sign.Core.Helpers;

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

        public string SignTransaction(string privateKey, string serializedTransactionBase64)
        {
            try
            {
                var serializedTransaction = System.Text.Encoding.UTF8.DecodeBase64(serializedTransactionBase64);
                var pkBytes = new Bytes(privateKey);
                var wallet = Lykke.Icon.Sdk.KeyWallet.Load(pkBytes);
                var transaction = TransactionDeserializer.Deserialize(serializedTransaction);
                var signedTr = new SignedTransaction(transaction, wallet);
                var props = signedTr.GetProperties();
                var serializedSignedTransaction = SignedTransaction.Serialize(props);
                var base64 = System.Text.Encoding.UTF8.EncodeBase64(serializedSignedTransaction);

                return base64;
            }
            catch (Exception e)
            {
                if (e is FormatException || e is ArgumentOutOfRangeException)
                    throw new ArgumentException(e.Message);

                throw;
            }
        }
    }
}

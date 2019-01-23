using System;
using System.Collections.Generic;
using System.Text;
using Lykke.Service.Icon.Sign.Core.Helpers;
using Lykke.Service.Icon.Sign.Services;
using Xunit;

namespace Lykke.Service.Icon.Sign.Tests
{
    public class IconServiceTest
    {
        [Fact]
        public void GenerateKeyPairTest()
        {
            IconSignService service = new IconSignService();

            var keyPair = service.GenerateKeyPair();

            Assert.NotNull(keyPair);
            Assert.NotNull(keyPair.PrivateKey);
            Assert.NotNull(keyPair.Address);
        }

        [Fact]
        public void SignTransactionTest()
        {
            IconSignService service = new IconSignService();
            var privateKey = SampleKeys.PrivateKeyString;
            var transactionSerialized =
                "icx_sendTransaction.from.hx4873b94352c8c1f3b2f09aaeccea31ce9e90bd31.nid.0x1.nonce.0x1.stepLimit.0x12345.timestamp.0x563a6cf330136.to.hx5bfdb090f43a808005ffc27c25b213145e80b7cd.value.0xde0b6b3a7640000.version.0x3";
            var base64Tx = System.Text.Encoding.UTF8.EncodeBase64(transactionSerialized);

            var signedTransaction = System.Text.Encoding.UTF8.DecodeBase64(service.SignTransaction(privateKey, base64Tx));
            Assert.Equal(@"icx_sendTransaction.from.hx4873b94352c8c1f3b2f09aaeccea31ce9e90bd31.nid.0x1.nonce.0x1.signature.PoxfZEKTEgNvsGLAXjt5Do9LL5ep1CTGyIFt3wcnGXZxivQQ\+\+Q\+n7maM2XR\+7Rtpe/t9BAnJZZ39JXjETF/OwA=.stepLimit.0x12345.timestamp.0x563a6cf330136.to.hx5bfdb090f43a808005ffc27c25b213145e80b7cd.value.0xde0b6b3a7640000.version.0x3",
                signedTransaction);
        }

        [Fact]
        public void SignNotValidTransactionTest()
        {
            IconSignService service = new IconSignService();
            var privateKey = SampleKeys.PrivateKeyString;
            var transactionSerialized =
                "testHex";
            Assert.Throws<System.ArgumentException>(() =>
            {
                var signedTransaction = service.SignTransaction(privateKey, transactionSerialized);
            });
        }
    }
}

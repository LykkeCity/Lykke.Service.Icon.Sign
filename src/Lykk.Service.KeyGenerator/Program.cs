using System;
using Lykke.Service.Icon.Sign.Services;

namespace Lykk.Service.Icon.KeyGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var iconService = new IconSignService();
            var keyPair = iconService.GenerateKeyPair();
            Console.WriteLine($"PrivateKey: {keyPair.PrivateKey}");
            Console.WriteLine($"Address(PublicAddress): {keyPair.Address}");
            Console.ReadLine();
        }
    }
}

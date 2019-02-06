using System;
using System.IO;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Lykke.Sdk;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.PlatformAbstractions;

namespace Lykke.Service.Icon.Sign
{
    internal sealed class Program
    {
        [UsedImplicitly]
        public static async Task Main(string[] args)
        {
#if DEBUG
            await LykkeStarter.Start<Startup>(true);
#else
            await LykkeStarter.Start<Startup>(false);
#endif
        }
    }
}

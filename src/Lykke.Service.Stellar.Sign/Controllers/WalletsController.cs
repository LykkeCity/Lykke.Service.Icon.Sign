using System.Net;
using Lykke.Service.Icon.Sign.Core.Domain;
using Lykke.Service.Icon.Sign.Core.Services;
using Lykke.Service.Icon.Sign.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lykke.Service.Icon.Sign.Controllers
{
    [Route("api/wallets")]
    public class WalletsController : Controller
    {
        private readonly IIconSignService _stellarService;

        public WalletsController(IIconSignService stellarService)
        {
            _stellarService = stellarService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(WalletResponse), (int)HttpStatusCode.OK)]
        public IActionResult Post()
        {
            var keyPair = _stellarService.GenerateKeyPair();

            return Ok(new WalletResponse
            {
                PrivateKey = keyPair.PrivateKey,
                PublicAddress = keyPair.Address,
                AddressContext = string.Empty
            });
        }
    }
}

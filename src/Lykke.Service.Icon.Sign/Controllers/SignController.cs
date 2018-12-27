using System;
using System.Linq;
using System.Net;
using Lykke.Common.Api.Contract.Responses;
using Lykke.Service.Icon.Sign.Core.Services;
using Lykke.Service.Icon.Sign.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lykke.Service.Icon.Sign.Controllers
{
    [Route("api/sign")]
    public class SignController : Controller
    {
        private readonly IIconSignService _iconService;

        public SignController(IIconSignService iconService)
        {
            _iconService = iconService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(SignResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public IActionResult SignTransaction([FromBody]SignRequest request)
        {
            if (request.PrivateKeys == null || request.PrivateKeys.Length < 1)
            {
                return BadRequest(ErrorResponse.Create("Invalid parameter").AddModelError("request.privateKeys", "Must contain at least one item"));
            }
            if (string.IsNullOrWhiteSpace(request.TransactionContext))
            {
                return BadRequest(ErrorResponse.Create("Invalid parameter").AddModelError("request.transactionContext", "Must be non empty"));
            }

            try
            {
                var xdrSigned = _iconService.SignTransaction(request.PrivateKeys.First(), request.TransactionContext);
                return Ok(new SignResponse
                {
                    SignedTransaction = xdrSigned
                });
            }
            catch (ArgumentException ex) when ("xdrBase64".Equals(ex.ParamName, StringComparison.Ordinal))
            {
                return BadRequest(ErrorResponse.Create("Invalid parameter").AddModelError("request.transactionContext", "Must be valid stellar transaction"));
            }
        }
    }
}

using Newtonsoft.Json;

namespace Lykke.Service.Icon.Sign.Models
{
    public class SignResponse
    {
        [JsonProperty("signedTransaction")]
        public string SignedTransaction { get; set; }
    }
}

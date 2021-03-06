﻿using Newtonsoft.Json;

namespace Lykke.Service.Icon.Sign.Models
{
    public class SignRequest
    {
        [JsonProperty("privateKeys")]
        public string[] PrivateKeys { get; set; }

        [JsonProperty("transactionContext")]
        public string TransactionContext { get; set; }
    }
}

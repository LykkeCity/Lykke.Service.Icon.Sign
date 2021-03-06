﻿using System.Collections.Generic;
using Lykke.Common.Health;
using Lykke.Service.Icon.Sign.Core.Services;

namespace Lykke.Service.Icon.Sign.Services
{
    // NOTE: See https://lykkex.atlassian.net/wiki/spaces/LKEWALLET/pages/35755585/Add+your+app+to+Monitoring
    public class HealthService : IHealthService
    {
        public string GetHealthViolationMessage()
        {
            return null;
        }

        public IEnumerable<HealthIssue> GetHealthIssues()
        {
            var issues = new HealthIssuesCollection();
            return issues;
        }
    }
}

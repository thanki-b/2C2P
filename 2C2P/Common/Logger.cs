using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using System;
using System.Collections.Generic;

namespace _2C2P.Common
{
    public class Logger : ILogger
    {

        public void LogInformation(string message)
        {
            _telemetryClient.TrackTrace(message, SeverityLevel.Information, _commonProperties);
        }

        public void LogError(string message)
        {
            _telemetryClient.TrackTrace(message, SeverityLevel.Error, _commonProperties);
        }

        public void LogMetric(string metric, double value)
        {
            _telemetryClient.GetMetric(metric).TrackValue(value);
        }

        private IDictionary<string, string> GenerateCommonProperties()
        {
            return new Dictionary<string, string>()
                {
                    {"Environment", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") }
                };

        }
    }
}
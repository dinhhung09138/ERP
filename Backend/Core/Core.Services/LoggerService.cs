using Core.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly ILogger<LoggerService> _logger;

        public LoggerService(ILogger<LoggerService> log)
        {
            _logger = log;
        }
        public bool AddErrorLog(string className, string methodName, params object[] listObject)
        {
            _logger.LogError($"{className} - {methodName}");
            foreach (var item in listObject)
            {
                _logger.LogError($"{JsonConvert.SerializeObject(item)}");
            }
            return true;
        }
    }
}

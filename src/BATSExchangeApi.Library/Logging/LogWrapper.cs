﻿using System;

using BATSExchangeApi.Library.Logging.Targets;

using NLog;

namespace BATSExchangeApi.Library.Logging
{
    public class LogWrapper : ILogWrapper
    {
        private readonly Logger _log;

        public LogWrapper()
        {
            LogManager.Configuration = new TargetFile().Initialize();
            _log = LogManager.GetLogger("BATSExchangeApi");
        }

        public void Error(string message)
        {
            _log.Error(message);
        }

        public void Error(Exception exception)
        {
            _log.Error(exception);
        }

        public void Warn(string message)
        {
            _log.Warn(message);
        }

        public void Warn(Exception exception)
        {
            _log.Warn(exception);
        }
    }
}

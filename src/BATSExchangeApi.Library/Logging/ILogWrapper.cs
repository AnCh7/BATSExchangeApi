using System;

namespace BATSExchangeApi.Library.Logging
{
    public interface ILogWrapper
    {
        void Error(string message);

        void Error(Exception exception);

        void Warn(string message);

        void Warn(Exception exception);
    }
}

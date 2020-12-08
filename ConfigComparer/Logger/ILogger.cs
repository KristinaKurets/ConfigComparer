using System;

namespace ConfigComparer.Logger
{
    public interface ILogger
    {
        void LogInfo(string message);
        void LogError(string message);
        void LogException(Exception ex);
    }
}

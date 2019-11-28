namespace CarStore.Helpers
{
    public enum LogTypes
    {
        File, Console
    }

    public static class LogHelper
    {
        private static LogBase logger = null;
        public static void Log(LogTypes target, string message)
        {
            switch (target)
            {
                case LogTypes.File:
                    logger = new FileLogger();
                    logger.Log(message);
                    break;
                case LogTypes.Console:
                    logger = new ConsoleLogger();
                    logger.Log(message);
                    break;
                default:
                    return;
            }
        }
    }
}

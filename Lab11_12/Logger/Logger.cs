namespace Lab11_12
{
    public class Logger
    {
        private static readonly string FILE_PATH = "logs.log";
        public static void D(string logMessage)
        {
            DateTime timestamp = DateTime.Now;
            string logType = "INFO";
            File.AppendAllText(FILE_PATH, $"{timestamp}: {logType} - {logMessage}\n");
        }
    }
}
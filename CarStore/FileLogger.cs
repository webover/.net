using System.IO;

namespace CarStore
{
    class FileLogger : LogBase
    {
        public string filePath = @"D:\carStoreLogs.txt";
        public override void Log(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.WriteLine(message);
                streamWriter.Close();
            }
        }
    }
}

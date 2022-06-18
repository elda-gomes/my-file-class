using My.Generic.List;
using System.IO;
using System.Text;

namespace MyFileClass
{
    public static class File
    {
        private const int _bufferSizeInBytes = 1024;

        //Doing the thing using my own List type, buffer, checking the end of file and converting bytes in string "manually" and using try/finally in order to close file
        public static string[] ReadAllLines(string filePath, Encoding encoding)
        {
            var fileStream = new FileStream(filePath, FileMode.Open);
            var buffer = new byte[_bufferSizeInBytes];
            var numberOfBytesRead = -1;
            var allLines = new List<string>();

            try
            {
                while (numberOfBytesRead != 0)
                {
                    numberOfBytesRead = fileStream.Read(buffer, 0, _bufferSizeInBytes);
                    allLines.Add(encoding.GetString(buffer, 0, numberOfBytesRead));
                }
            }
            finally
            {
                fileStream.Close();
            }        

            return allLines.ToArray();
        }

        public static string[] ReadAllLines(string filePath)
        {
            return File.ReadAllLines(filePath, System.Text.Encoding.Default);
        }

        //Doing the thing using StreamReader and using()
        public static string ReadAllText(string filePath, Encoding encoding)
        {
            var text = new StringBuilder();

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            using (var streamReader = new StreamReader(fileStream, encoding))
            {
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();
                    text.AppendLine(line);
                }
            }

            return text.ToString();
        }

        public static string ReadAllText(string filePath)
        {
            return File.ReadAllText(filePath, Encoding.Default);
        }
    }
}

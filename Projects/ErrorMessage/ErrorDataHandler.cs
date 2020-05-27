using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace ErrorMessage
{
    public class ErrorData
    {
        public string Header { get; set; }
        public string ErrorFile { get; set; }


        public ErrorData() : this(string.Empty, string.Empty) { }
        public ErrorData(string header, string errorFile)
        {
            Header = header;
            ErrorFile = errorFile;
        }
    }

    public class ErrorDataHandler
    {
        static readonly string errorDataFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ErrorData.json");

        public static ErrorData Load()
        {
            if (!File.Exists(errorDataFile)) throw new FileNotFoundException("File " + errorDataFile + " not found");

            return JsonConvert.DeserializeObject<ErrorData>(File.ReadAllText(errorDataFile));
        }

        public static void Save(ErrorData errorData)
        {
            JsonConvert.SerializeObject(errorData, Formatting.Indented);
        }
    }

}

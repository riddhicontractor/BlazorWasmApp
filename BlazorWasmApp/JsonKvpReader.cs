using I18NPortable;
using Newtonsoft.Json;

namespace BlazorWasmApp
{
    public class JsonKvpReader : ILocaleReader
    {
        public Dictionary<string, string> Read(Stream stream)
        {
            using (var streamReader = new StreamReader(stream))
            {
                var json = streamReader.ReadToEnd();

                return JsonConvert
                    .DeserializeObject<Dictionary<string, string>>(json)
                    .ToDictionary(x => x.Key.Trim(), x => x.Value.Trim().UnescapeLineBreaks());
            }
        }
    }
}
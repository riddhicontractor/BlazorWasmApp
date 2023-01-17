namespace BlazorWasmApp
{
    public interface ILocaleReader
    {
        Dictionary<string, string> Read(Stream stream);
    }
}
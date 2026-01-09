namespace Drasi.Source.Directory.Models;

public sealed class FileSourceElement(string Id, string FileName)
{
    public string Id { get; } = Id;
    public string FileName { get; } = FileName;
    public string ElementLabel { get; } = "File";
}
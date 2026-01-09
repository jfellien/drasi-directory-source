using System.Text.Json.Nodes;
using Drasi.Source.SDK.Models;

namespace Drasi.Source.Directory.Models;

public static class ModelsExtensions
{
    public static SourceElement ToSourceElement(this FileSourceElement source)
    {
        JsonObject jsonObject = new()
        {
            {
                nameof(source.FileName), source.FileName
            }
        };
        
        return new SourceElement(
            source.Id, 
            [source.ElementLabel], 
            jsonObject);
    }
}
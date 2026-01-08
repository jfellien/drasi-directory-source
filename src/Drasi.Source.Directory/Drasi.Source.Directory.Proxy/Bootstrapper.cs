using System.Text.Json.Nodes;
using Drasi.Source.Directors.Models;
using Drasi.Source.SDK;
using Drasi.Source.SDK.Models;

namespace Drasi.Source.Directory.Proxy;

/// <summary>
/// Represents the bootstrap handler for initializing and managing the source
/// components. The <c>Bootstrapper</c> class implements the <c>IBootstrapHandler</c>
/// interface, providing functionality to bootstrap data elements required by the source system.
/// </summary>
/// <remarks>
/// This class processes <c>BootstrapRequest</c> instances and asynchronously
/// yields <c>SourceElement</c> instances to initialize the source with data.
/// </remarks>
/// <seealso cref="IBootstrapHandler"/>
internal class Bootstrapper : IBootstrapHandler
{
    public async IAsyncEnumerable<SourceElement> Bootstrap(BootstrapRequest request, CancellationToken ct = new ())
    {
        FileSourceElement sampleFileSource = new(
            "sample-record-1", 
            "sample-file.txt");
        
        yield return sampleFileSource.ToSourceElement();
    }
}
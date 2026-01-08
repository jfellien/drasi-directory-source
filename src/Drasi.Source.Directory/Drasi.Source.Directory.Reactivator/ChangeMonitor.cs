using System.Text.Json.Nodes;
using Drasi.Source.Directors.Models;
using Drasi.Source.SDK;
using Drasi.Source.SDK.Models;
using Microsoft.Extensions.Configuration;

namespace Drasi.Source.Directory.Reactivator;

internal class ChangeMonitor : IChangeMonitor
{
    public const string STATE_STORE_KEY = "file-counter";
    private readonly IStateStore stateStore;
    
    public ChangeMonitor(IStateStore stateStore, IConfiguration configuration)
    {
        this.stateStore = stateStore;
        
        Console.WriteLine($"{nameof(Reactivator)} State Store assigned");
        Console.WriteLine($"{nameof(Reactivator)} Change Monitor initialized.");
    }
    
    public async IAsyncEnumerable<SourceChange> Monitor(CancellationToken cancellationToken = new ())
    {
        Console.WriteLine("Starting Change Monitor...");
        
        uint counter = BitConverter.ToUInt32(await stateStore.Get(STATE_STORE_KEY) ?? "\0\0\0\0"u8.ToArray());
        long reactivatorStart = (DateTimeOffset.UtcNow.Ticks - DateTimeOffset.UnixEpoch.Ticks) * 100;
        
        Console.WriteLine($"Current Change Count: {counter}");
        Console.WriteLine("Monitoring...");
        
        while (cancellationToken.IsCancellationRequested == false)
        {
            counter++;
            string fileId = $"file-{counter}";
            string fileName = $"fileName-{counter}.txt";
            
            Console.WriteLine($"File: {fileName}");
            
            FileSourceElement fileSource = new(fileId, fileName);
            
            yield return new SourceChange(
                ChangeOp.INSERT,
                fileSource.ToSourceElement(),
                DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                reactivatorStart,
                counter);

            Console.WriteLine($"Current Change Count: {counter}");
            await stateStore.Put(STATE_STORE_KEY, BitConverter.GetBytes(counter));
            
            Console.WriteLine($"Start Delay...");
            await Task.Delay(1000, cancellationToken);
            
            Console.WriteLine($"Stop Delay...");
        }
    }
}
using Drasi.Source.SDK;
using Drasi.Source.Directory.Proxy;

// It's the default startup for custom sources
SourceProxy proxy = new SourceProxyBuilder()
    .UseBootstrapHandler<Bootstrapper>()
    .Build();
    
await proxy.StartAsync();
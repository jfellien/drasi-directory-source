using Drasi.Source.Directory.Reactivator;
using Drasi.Source.SDK;

var reactivator = new ReactivatorBuilder()
    .UseChangeMonitor<ChangeMonitor>()
    .UseDeprovisionHandler<DeprovisionHandler>()
    .Build();

await reactivator.StartAsync();
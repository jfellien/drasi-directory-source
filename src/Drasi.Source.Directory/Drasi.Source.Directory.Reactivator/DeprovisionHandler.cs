using Drasi.Source.SDK;

namespace Drasi.Source.Directory.Reactivator;

public class DeprovisionHandler : IDeprovisionHandler
{
    public async Task Deprovision(IStateStore stateStore)
    {
        await stateStore.Delete(ChangeMonitor.STATE_STORE_KEY);
    }
}
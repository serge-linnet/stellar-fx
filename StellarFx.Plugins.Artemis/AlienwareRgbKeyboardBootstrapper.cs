using Artemis.Core;
using Artemis.Core.DeviceProviders;
using Artemis.Core.Services;
using RGB.NET.Core;

namespace StellarFx.Plugins.Artemis
{
    public class LightFxBootstrapper : PluginBootstrapper
    {
        public override void OnPluginLoaded(Plugin plugin)
        {
        }
    }

    public class LightFxDeviceProvider : DeviceProvider
    {
        private readonly IDeviceService  rgbService;

        public LightFxDeviceProvider(IDeviceService rgbService)
        {
            this.rgbService = rgbService;
        }

        public override IRGBDeviceProvider RgbDeviceProvider => LightFxRgbDeviceProvider.Instance;

        public override void Disable()
        {
            this.rgbService.RemoveDeviceProvider(this);
        }

        public override void Enable()
        {
            this.rgbService.AddDeviceProvider(this);
        }
    }
}
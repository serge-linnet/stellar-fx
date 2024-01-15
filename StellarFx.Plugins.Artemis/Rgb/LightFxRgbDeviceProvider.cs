using RGB.NET.Core;
using StellarFx.LightFx;
using StellarFx.LightFx;

namespace StellarFx.Plugins.Artemis
{
    public class LightFxRgbDeviceProvider : AbstractRGBDeviceProvider
    {
        private static LightFxRgbDeviceProvider? instance;
        private static object syncRoot = new object();
        private LightFxService _lightFx;

        public static LightFxRgbDeviceProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        instance = new LightFxRgbDeviceProvider();
                    }

                }
                return instance;
            }
        }

        public LightFxRgbDeviceProvider()
        {
            _lightFx = new LightFxService();
        }

        protected override void InitializeSDK()
        {
            _lightFx.Initialize();
        }

        protected override IEnumerable<IRGBDevice> LoadDevices()
        {
            var numOfDevices = _lightFx.GetNumberOfDevices();

            var devices = new Dictionary<uint, LFX_DeviceType>();
            for (uint devIdx = 0; devIdx < numOfDevices; devIdx++)
            {
                var (devType, _) = _lightFx.GetDeviceDescription(devIdx);

                if (devType == LFX_DeviceType.LFX_DEVTYPE_KEYBOARD)
                {
                    var info = new LightFxKeyboardDeviceInfo();
                    yield return new LightFxKeyboardDevice(info, new LightFxUpdateQueue(_lightFx, devIdx, GetUpdateTrigger()));
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _lightFx.Release();
            }
        }
    }
}
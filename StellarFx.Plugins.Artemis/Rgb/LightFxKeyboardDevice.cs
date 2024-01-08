using RGB.NET.Core;

namespace StellarFx.Plugins.Artemis
{
    public class LightFxKeyboardDevice : AbstractRGBDevice<LightFxKeyboardDeviceInfo>, IKeyboard
    {
        IKeyboardDeviceInfo IKeyboard.DeviceInfo => DeviceInfo;

        public LightFxKeyboardDevice(LightFxKeyboardDeviceInfo deviceInfo, IUpdateQueue updateQueue) : base(deviceInfo, updateQueue)
        {
        }
    }
}
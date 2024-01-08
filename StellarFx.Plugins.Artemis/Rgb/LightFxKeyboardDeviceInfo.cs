using RGB.NET.Core;

namespace StellarFx.Plugins.Artemis
{
    public class LightFxKeyboardDeviceInfo : IRGBDeviceInfo, IKeyboardDeviceInfo
    {
        public RGBDeviceType DeviceType => RGBDeviceType.Keyboard;

        public string DeviceName => "M15 R7";

        public string Manufacturer => "Alienware";

        public string Model => "M15 R7";

        public object? LayoutMetadata { get; set; }

        public KeyboardLayoutType Layout => KeyboardLayoutType.ANSI;
    }
}
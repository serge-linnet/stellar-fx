namespace StellarFx.App.LightFx
{
    public enum LFX_DeviceType : ushort
    {
        LFX_DEVTYPE_UNKNOWN = 0x00,
        LFX_DEVTYPE_NOTEBOOK = 0x01,
        LFX_DEVTYPE_DESKTOP = 0x02,
        LFX_DEVTYPE_SERVER = 0x03,
        LFX_DEVTYPE_DISPLAY = 0x04,
        LFX_DEVTYPE_MOUSE = 0x05,
        LFX_DEVTYPE_KEYBOARD = 0x06,
        LFX_DEVTYPE_GAMEPAD = 0x07,
        LFX_DEVTYPE_SPEAKER = 0x08,
        LFX_DEVTYPE_OTHER = 0xFF
    }
}
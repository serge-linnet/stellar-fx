using StellarFx.LightFx;

namespace StellarFx.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lightFx = new LightFxService();
            lightFx.Initialize();
            try
            {
                uint numberOfDevices = lightFx.GetNumberOfDevices();
                Console.WriteLine($"Number of devices = {numberOfDevices}.");

                var devices = new Dictionary<uint, LFX_DeviceType>();
                for (uint devIdx = 0; devIdx < numberOfDevices; devIdx++)
                {
                    var (devType, devDesc) = lightFx.GetDeviceDescription(devIdx);
                    devices.Add(devIdx, devType);
                    Console.WriteLine($"{devIdx}: {devDesc} ({devType}).");
                }

                if (!devices.ContainsValue(LFX_DeviceType.LFX_DEVTYPE_KEYBOARD))
                {
                    throw new Exception("Keyboard not found.");
                }

                var keyboardIdx = devices.First(d => d.Value == LFX_DeviceType.LFX_DEVTYPE_KEYBOARD).Key;

                var rnd = new Random();
                SetRndColor(lightFx, keyboardIdx, rnd, new[] { 0, 1, 23 });
                SetRndColor(lightFx, keyboardIdx, rnd, new[] { 2, 10, 19 });

                var version = lightFx.GetVersion();
                Console.WriteLine($"LightFX version: {version}.");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                lightFx.Release();
            }

            static void SetRndColor(LightFxService lightFx, uint keyboardIdx, Random rnd, int[] lights)
            {
                var color = new LFX_Color
                {
                    red = (byte)rnd.Next(0, 255),
                    green = (byte)rnd.Next(0, 255),
                    blue = (byte)rnd.Next(0, 255),
                    brightness = 255
                };

                foreach (var light in lights)
                {
                    lightFx.SetLightColor(keyboardIdx, (ushort)light, color);
                }
            }

            static void MapLights(LightFxService lightFx, uint deviceIdx)
            {
                var numOfLights = lightFx.GetNumberOfLights(deviceIdx);
                Console.WriteLine($"Number of lingths: {numOfLights}");

                for (uint i = 0; i < numOfLights; i++)
                {
                    var lightIdx = i;
                    var desc = lightFx.GetLightDescription(deviceIdx, lightIdx);

                    var color = new LFX_Color
                    {
                        red = 00,
                        green = 100,
                        blue = 100,
                        brightness = 255
                    };

                    lightFx.SetLightColor(deviceIdx, lightIdx, color);

                    Console.WriteLine($"{lightIdx}: {desc}");
                }
            }
        }
    }
}
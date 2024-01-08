using StellarFx.App.LightFx;
using System.Text;

namespace StellarFx.LightFx
{
    public class LightFxService
    {
        private const int BufferSize = 256;

        public void Initialize()
        {
            var result = LightFxSdk.LFX_Initialize();
            AssertSuccess(nameof(LightFxSdk.LFX_Initialize), result);
        }

        public uint GetNumberOfDevices()
        {
            uint numberOfDevices = 0;
            var result = LightFxSdk.LFX_GetNumDevices(out numberOfDevices);
            AssertSuccess(nameof(LightFxSdk.LFX_GetNumDevices), result);
            return numberOfDevices;
        }

        public (LFX_DeviceType, string) GetDeviceDescription(uint devIdx)
        {
            var devDesc = new StringBuilder(BufferSize);
            LFX_DeviceType devType;
            var result = LightFxSdk.LFX_GetDeviceDescription(devIdx, devDesc, BufferSize, out devType);
            AssertSuccess(nameof(LightFxSdk.LFX_GetDeviceDescription), result);
            return (devType, devDesc.ToString());
        }

        public uint GetNumberOfLights(uint devIdx)
        {
            uint numOfLights = 0;
            var result = LightFxSdk.LFX_GetNumLights(devIdx, out numOfLights);
            AssertSuccess(nameof(LightFxSdk.LFX_GetDeviceDescription), result);
            return numOfLights;
        }

        public string GetLightDescription(uint devIdx, uint lightIdx)
        {
            var desc = new StringBuilder(BufferSize);
            var result = LightFxSdk.LFX_GetLightDescription(devIdx, lightIdx, desc, BufferSize);
            AssertSuccess(nameof(LightFxSdk.LFX_Update), result);
            return desc.ToString();
        }

        public string GetVersion()
        {
            var version = new StringBuilder(BufferSize);
            var result = LightFxSdk.LFX_GetVersion(version, 265);
            AssertSuccess(nameof(LightFxSdk.LFX_Update), result);
            return version.ToString();
        }

        public void Update()
        {
            var result = LightFxSdk.LFX_Update();
            AssertSuccess(nameof(LightFxSdk.LFX_Update), result);
        }

        public void UpdateDefault()
        {
            var result = LightFxSdk.LFX_UpdateDefault();
            AssertSuccess(nameof(LightFxSdk.LFX_UpdateDefault), result);
        }

        public void SetLightColor(uint deviceIdx, uint lightIdx, LFX_Color color)
        {
            var result = LightFxSdk.LFX_SetLightColor(deviceIdx, lightIdx, ref color);
            AssertSuccess(nameof(LightFxSdk.LFX_SetLightColor), result);
        }

        public void SetLightActionColorEx(uint deviceIdx, uint lightIdx, LFX_Color color, LFX_Color color2)
        {
            var action = LFX_Action.LFX_ACTION_MORPH;
            var result = LightFxSdk.LFX_SetLightActionColorEx(deviceIdx, lightIdx, action, ref color, ref color2);
            AssertSuccess(nameof(LightFxSdk.LFX_SetLightColor), result);
        }

        public void Reset()
        {
            var result = LightFxSdk.LFX_Reset();
            AssertSuccess(nameof(LightFxSdk.LFX_SetLightColor), result);
        }

        public void Release()
        {
            try
            {
                LightFxSdk.LFX_Release();
            }
            catch
            {
                // no-op
            }
        }

        private void AssertSuccess(string func, LFX_Result result)
        {
            if (result != LFX_Result.LFX_SUCCESS)
            {
                throw new Exception($"{func} has returned unexpected result ({result}).");
            }
        }
    }
}

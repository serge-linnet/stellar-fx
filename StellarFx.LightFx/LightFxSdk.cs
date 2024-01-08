using System.Runtime.InteropServices;
using System.Text;

namespace StellarFx.App.LightFx
{
    internal static class LightFxSdk
    {
        /// <summary>
        /// Update the entire system, submitting any state changes to hardware 
        /// made since the last LFX_Reset() call.
        /// </summary>
        /// <returns>
        /// LFX_ERROR_NOINIT if the system is not yet initialized.
        /// LFX_ERROR_NODEVS if the system is initialized but no devices are available.
        /// LFX_SUCCESS otherwise.
        /// </returns>
        [DllImport("LightFX.dll")]
        public static extern LFX_Result LFX_Update();

        /// <summary>
        /// Initializes the LightFX 2.0 system.
        /// This function must be called prior to any other library calls being made.If this
        /// function is not called, the system will not be initialized and the other functions
        /// will return LFX_ERROR_NOINIT or LFX_FAILURE.
        /// </summary>
        /// <returns>
        /// LFX_SUCCESS if the system is successfully initialized, or was already initialized.
        /// LFX_ERROR_NODEVS if the system is initialized, but no devices are available.
        /// LFX_FAILURE if initialization fails.
        /// </returns>
        [DllImport("LightFX.dll")]
        public static extern LFX_Result LFX_Initialize();

        /// <summary>
        /// Get the number of devices attached to the LightFX system.
        /// </summary>
        /// <param name="numberOfDevices">Populates a uint with the current number of attached devices.</param>
        /// <returns>
        /// LFX_ERROR_NOINIT if the system is not yet initialized.
        /// LFX_ERROR_NODEVS if the system is initialized but no devices are available, leaving the param untouched.
        /// LFX_SUCCESS otherwise.
        /// </returns>
        [DllImport("LightFX.dll")]
        public static extern LFX_Result LFX_GetNumDevices(out uint numberOfDevices);

        /// <summary>
        /// Get the description of a device attached to the system.
        /// </summary>
        /// <param name="devIdx">Accepts an index to the device.</param>
        /// <param name="devDesc">Populates a character string with the device's description.</param>
        /// <param name="bufferSize"></param>
        /// <param name="devType">Populates a ushort with the device type (see LFXDecl.h for device types).</param>
        /// <returns>
        /// LFX_ERROR_NOINIT if the system is not yet initialized.
        /// LFX_ERROR_NODEVS if the system is initialized but no devices are available.
        /// LFX_ERROR_BUFFSIZE if the buffer provided is too small.
        /// LFX_FAILURE or LFX_SUCCESS otherwise.
        /// </returns>
        [DllImport("LightFX.dll")]
        public static extern LFX_Result LFX_GetDeviceDescription(uint devIdx, StringBuilder devDesc, uint bufferSize, out LFX_DeviceType devType);

        /// <summary>
        /// Sets the current color of a light attached to a device.
        /// Important: 
        /// This function changes the current color stored in the active state since the last LFX_Reset() call.
        /// It does NOT immediately update the physical light settings, until a call to LFX_Update() is made.
        /// </summary>
        /// <param name="devIdx">Device index.</param>
        /// <param name="location">Light index.</param>
        /// <param name="color">Color value.</param>
        /// <returns>
        /// LFX_ERROR_NOINIT if the system is not yet initialized.
        /// LFX_FAILURE or LFX_SUCCESS otherwise.
        /// </returns>
        [DllImport("LightFX.dll")]
        public static extern LFX_Result LFX_SetLightColor(uint devIdx, uint location, ref LFX_Color color);

        /// <summary>
        /// Release the LightFX 2.0 system.
        /// This function may be called when the system is no longer needed. 
        /// If this function is not called, release will still occur on process detach.
        /// </summary>
        [DllImport("LightFX.dll")]
        public static extern LFX_Result LFX_Release();

        /// <summary>
        /// Reset the state of the system to 'off' for any lights attached to any devices.
        /// Note that the change(s) to the physical light(s) do not occur immediately, rather
        /// only after an LFX_Update() call is made.
        /// To disable all lights, call LFX_Reset(), immediately followed by LFX_Update().
        /// </summary>
        /// <returns>
        /// LFX_ERROR_NOINIT if the system is not yet initialized.
        /// LFX_ERROR_NODEVS if there are no devices available to reset.
        /// LFX_SUCCESS otherwise.
        /// </returns>
        [DllImport("LightFX.dll")] public static extern LFX_Result LFX_Reset();

        /// <summary>
        /// Update the entire system, submitting any state changes made since the last LFX_Reset()
        /// call to the hardware, and set the appropriate flags to make the new state the
        /// power-on default.
        /// </summary>
        /// <returns>
        /// LFX_ERROR_NOINIT if the system is not yet initialized.
        /// LFX_ERROR_NODEVS if the system is initialized but no devices are available.
        /// LFX_FAILURE or LFX_SUCCESS otherwise.
        /// </returns>
        [DllImport("LightFX.dll")]
        public static extern LFX_Result LFX_UpdateDefault();

        /// <summary>
        /// Get the number of lights attached to a device in the LightFX system
        /// </summary>
        /// <param name="devIdx">Accepts an index to the device.</param>
        /// <param name="numLights">Populates a uint with the current number of attached lights for the device index.</param>
        /// <returns>        
        /// LFX_ERROR_NOINIT if the system is not yet initialized.
        /// LFX_ERROR_NODEVS if the system is initialized but no devices are available at the index provided.
        /// LFX_ERROR_NOLIGHTS if no lights are available at the device index provided.
        /// LFX_FAILURE or LFX_SUCCESS otherwise.</returns>
        [DllImport("LightFX.dll")]
        public static extern LFX_Result LFX_GetNumLights(uint devIdx, out uint numLights);

        /// <summary>
        /// Get the description of a light attached to a device
        /// Inputs:	Accepts an index to the device and an index to the light
        /// Outputs: Populates a character string with the light's description
        /// </summary>
        /// <param name="devIdx">Device index.</param>
        /// <param name="lightIdx">Light index.</param>
        /// <param name="lightDesc">Light description.</param>
        /// <param name="bufferSize">Buffer size.</param>
        /// <returns> 
        /// LFX_ERROR_NOINIT if the system is not yet initialized.
        /// LFX_ERROR_NODEVS if the system is initialized but no devices are available at the index provided.
        /// LFX_ERROR_NOLIGHTS if no lights are available at the device and light index provided.
        /// LFX_ERROR_BUFFSIZE if the buffer provided is too small in size.
        /// LFX_FAILURE or LFX_SUCCESS otherwise.
        /// </returns>
        [DllImport("LightFX.dll")]
        public static extern LFX_Result LFX_GetLightDescription(uint devIdx, uint lightIdx, StringBuilder lightDesc, uint bufferSize);

        /// <summary>
        /// Get API Version
        /// </summary>
        /// <param name="version">Populates a character string with the API version.</param>
        /// <param name="bufferSize">Buffer size.</param>
        /// <returns>
        /// LFX_ERROR_BUFFSIZE if the buffer provided is too small.
        /// LFX_FAILURE or LFX_SUCCESS otherwise.
        /// </returns>
        [DllImport("LightFX.dll")]
        public static extern LFX_Result LFX_GetVersion(StringBuilder version, uint bufferSize);

        /// <summary>
        /// Sets the tempo for actions.
        /// Important: 
        /// This function changes the current tempo or timing to be used for the next actions.
        /// It does NOT immediately update the physical light settings, until a call to LFX_Update() is made.
        /// </summary>
        /// <param name="timing">Accepts a 32-bit timing value.</param>
        [DllImport("LightFX.dll")]
        public static extern LFX_Result LFX_SetTiming(int timing);

        /// <summary>
        /// Get the location of a light attached to a device.
        /// </summary>
        /// <param name="devIdx">Device index.</param>
        /// <param name="lightIdx">Light index.</param>
        /// <param name="lightPos">Populates a LFX_POSITION structure with the light's position.</param>
        /// <returns>
        /// LFX_ERROR_NOINIT if the system is not yet initialized.
        /// LFX_ERROR_NODEVS if the system is initialized but no devices are available at the index provided.
        /// LFX_ERROR_NOLIGHTS if no lights are available at the device and light index provided.
        /// LFX_SUCCESS otherwise.
        /// </returns>
        [DllImport("LightFX.dll")]
        public static extern LFX_Result LFX_GetLightLocation(uint devIdx, uint lightIdx, ref LFX_Position lightPos);

        /// <summary>
        /// Get the current color of a light attached to a device.
        /// Important: 
        /// This function provides the current color stored in the active state
        /// since the last LFX_Reset() call, it does not necessarily reflect the color of the
        /// physical light.To ensure that the returned value represents the state of the
        /// physical light, call LFX_GetLightColor immediately after a call to LFX_Update() and
        /// before the next call to LFX_Reset().
        /// </summary>
        /// <param name="devIdx">Device index.</param>
        /// <param name="lightIdx">Light index</param>
        /// <param name="color">Populates a LFX_COLOR structure with the color.</param>
        /// <returns>
        /// LFX_ERROR_NOINIT if the system is not yet initialized.
        /// LFX_ERROR_NODEVS if the system is initialized but no devices are available at the index provided.
        /// LFX_ERROR_NOLIGHTS if no lights are available at the device and light index provided.
        /// LFX_FAILURE or LFX_SUCCESS otherwise.
        /// </returns>
        [DllImport("LightFX.dll")]
        public static extern LFX_Result LFX_GetLightColor(uint devIdx, uint lightIdx, ref LFX_Color color);

        /// <summary>
        /// Sets the color of a location for any devices with lights in that corresponding location.
        /// 
        /// Important: 
        /// This function changes the current color stored in the active state
        /// since the last LFX_Reset() call.It does NOT immediately update the physical light
        /// settings, until a call to LFX_Update() is made.
        /// 
        /// Location Mask Note: 
        ///     Location mask is a 32-bit field, where each of the first 27 bits represent
        ///     a zone in the virtual cube representing the system (see LFXDecl.h).
        /// 
        /// Color Packing Note: 
        ///     Color is packed into a 32-bit value, as follows:
        ///     Bits 0-7: Blue
        ///     Bits 8-15: Green
        ///     Bits 16-23: Red
        ///     Bits 24-32: Brightness
        /// </summary>
        /// <param name="locationMask">Location mask.</param>
        /// <param name="packedColor">Packed color.</param>
        [DllImport("LightFX.dll")]
        public static extern LFX_Result LFX_Light(uint locationMask, uint packedColor);

        /// <summary>
        /// Sets the primary and secondary color and an action type for any devices with lights in a location.
        /// 
        /// Important: 
        /// This function changes the current color stored in the active state
        /// since the last LFX_Reset() call.It does NOT immediately update the physical light
        /// settings, until a call to LFX_Update() is made.
        /// 
        /// Location Mask Note: 
        ///     Location mask is a 32-bit field, where each of the first 27 bits represent
        ///     a zone in the virtual cube representing the system (see LFXDecl.h).
        /// 
        /// Color Packing Note: 
        ///     Color is packed into a 32-bit value, as follows:
        ///     Bits 0-7: Blue
        ///     Bits 8-15: Green
        ///     Bits 16-23: Red
        ///     Bits 24-32: Brightness
        /// </summary>
        /// <param name="locationMaskPrimary">Primary location mask.</param>
        /// <param name="packedColorPrimary">Primary packed color.</param>
        /// <param name="locationMaskSecondary">Secondary location mask.</param>
        /// <param name="packedColorSecondary">Secondary packed color.</param>
        /// <returns>
        /// LFX_ERROR_NOINIT if the system is not yet initialized.
        /// LFX_FAILURE or LFX_SUCCESS otherwise.
        /// </returns>
        [DllImport("LightFX.dll")]
        public static extern LFX_Result LFX_ActionColorEx(
            uint locationMaskPrimary, uint packedColorPrimary,
            uint locationMaskSecondary, uint packedColorSecondary);

        /// <summary>
        /// Sets the primary color and an action type to a light.
        /// 
        /// Important: 
        /// This function changes the current color stored in the active state
        /// since the last LFX_Reset() call.It does NOT immediately update the physical light
        /// settings, until a call to LFX_Update() is made.
        /// </summary>
        /// <param name="devIdx">Device index.</param>
        /// <param name="lightIdx">Light index.</param>
        /// <param name="actionType">Action type.</param>
        /// <param name="color">Color.</param>
        /// <returns>
        /// LFX_ERROR_NOINIT if the system is not yet initialized.
        /// LFX_FAILURE or LFX_SUCCESS otherwise.
        /// </returns>
        [DllImport("LightFX.dll")]
        public static extern LFX_Result LFX_SetLightActionColor(uint devIdx, uint lightIdx, LFX_Action actionType, ref LFX_Color color);

        /// <summary>
        /// Sets the primary and secondary colors and an action type to a light.
        /// Important: 
        /// This function changes the current color and action type stored in the active state
        /// since the last LFX_Reset() call. It does NOT immediately update the physical light
        /// settings, until a call to LFX_Update() is made. If the action type is not a morph, 
        /// then the secondary color is ignored.
        /// </summary>
        /// <param name="devIdx">Device index.</param>
        /// <param name="lightIdx">Light index.</param>
        /// <param name="actionType">Action type.</param>
        /// <param name="primaryColor">Primary color</param>
        /// <param name="secondaryColor">Secondary color</param>
        /// <returns>
        /// LFX_ERROR_NOINIT if the system is not yet initialized.
        /// LFX_FAILURE or LFX_SUCCESS otherwise.
        /// </returns>
        [DllImport("LightFX.dll")]
        public static extern
            LFX_Result LFX_SetLightActionColorEx(
            uint devIdx, uint lightIdx, LFX_Action actionType,
            ref LFX_Color primaryColor, ref LFX_Color secondaryColor);

        /// <summary>
        /// Sets the primary color and an action type for any devices with lights in a location.
        /// 
        /// Important: 
        /// This function changes the current primary color and action type stored in the active state
        /// since the last LFX_Reset() call. It does NOT immediately update the physical light
        /// settings, until a call to LFX_Update() is made. If the action type is a morph, then 
        /// the secondary color for the action is black.
        /// 
        /// Location Mask Note: 
        /// Location mask is a 32-bit field, where each of the first 27 bits represent 
        /// a zone in the virtual cube representing the system (see LFXDecl.h)
        /// 
        /// Color Packing Note: 
        /// Color is packed into a 32-bit value, as follows:
        ///     Bits 0-7: Blue
        ///     Bits 8-15: Green
        ///     Bits 16-23: Red
        ///     Bits 24-32: Brightness
        /// </summary>
        /// <param name="locationMask">Location mask.</param>
        /// <param name="packedColor">Packed color.</param>
        /// <param name="actionType">Action type.</param>
        /// <returns> 
        /// LFX_ERROR_NOINIT if the system is not yet initialized.
        /// LFX_ERROR_NOLIGHTS if no lights were found at the location mask specified.
        /// LFX_FAILURE if some other error occurred 
        /// LFX_SUCCESS otherwise.
        /// </returns>
        [DllImport("LightFX.dll")] public static extern LFX_Result LFX_ActionColor(uint locationMask, uint packedColor, LFX_Action actionType);
    }
}
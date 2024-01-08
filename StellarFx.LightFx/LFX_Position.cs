
/*  */
/// <summary>
/// Position, encoded into a 3-axis value.
/// Note that these are relative to the lower, left, rear corner of the device's bounding box.
/// X increases from left to right.
/// Y increases from bottom to top.
/// Z increases from back to front.
/// </summary>
public struct LFX_Position
{
    public byte x;
    public byte y;
    public byte z;
}
/***








    /// <summary>
    Function: LFX_GetLightColor
    Description:
        Get the current color of a light attached to a device
    Important: 
        This function provides the current color stored in the active state
        since the last LFX_Reset() call, it does not necessarily reflect the color of the
        physical light. To ensure that the returned value represents the state of the
        physical light, call LFX_GetLightColor immediately after a call to LFX_Update() and
        before the next call to LFX_Reset().
    Inputs:	Accepts an index to the device and an index to the light
    Outputs: Populates a LFX_COLOR structure with the light's description
    /// <returns> 
        LFX_ERROR_NOINIT if the system is not yet initialized.
        LFX_ERROR_NODEVS if the system is initialized but no devices are available at the index provided.
        LFX_ERROR_NOLIGHTS if no lights are available at the device and light index provided.
        LFX_FAILURE or LFX_SUCCESS otherwise.
    /// </summary>
    [DllImport("LightFX.dll")]        public static extern LFX_Result LFX_GetLightColor(const unsigned int, const unsigned int, PLFX_COLOR const);

    /// <summary>
    Function: LFX_SetLightColor
    Description:
        Sets the current color of a light attached to a device
    Important: 
        This function changes the current color stored in the active state
        since the last LFX_Reset() call. It does NOT immediately update the physical light
        settings, until a call to LFX_Update() is made.
    Inputs:	Accepts an index to the device, an index to the light, and a new LFX_COLOR value
    Outputs: None
    /// <returns> 
        LFX_ERROR_NOINIT if the system is not yet initialized.
        LFX_FAILURE or LFX_SUCCESS otherwise.
    /// <summary>
    [DllImport("LightFX.dll")]        public static extern LFX_Result LFX_SetLightColor(const unsigned int, const unsigned int, const PLFX_COLOR);

    /// <summary>
    Function: LFX_Light
    Description:
        Sets the color of a location for any devices with lights in that 
        corresponding location.
    Important: 
        This function changes the current color stored in the active state
        since the last LFX_Reset() call. It does NOT immediately update the physical light
        settings, until a call to LFX_Update() is made.
    Location Mask Note: 
        Location mask is a 32-bit field, where each of the first 27 bits represent 
        a zone in the virtual cube representing the system (see LFXDecl.h)
    Color Packing Note: 
        Color is packed into a 32-bit value, as follows:
            Bits 0-7: Blue
            Bits 8-15: Green
            Bits 16-23: Red
            Bits 24-32: Brightness
    Inputs:	Accepts a 32-bit location mask and a packed color value
    Outputs: None
    /// <returns> 
        LFX_ERROR_NOINIT if the system is not yet initialized.
        LFX_ERROR_NOLIGHTS if no lights were found at the location mask specified.
        LFX_FAILURE if some other error occurred 
        LFX_SUCCESS otherwise.
    /// <summary>
    [DllImport("LightFX.dll")]        public static extern LFX_Result LFX_Light(const unsigned int, const unsigned int);

    /// <summary>
    Function: LFX_SetLightActionColor
    Description:
        Sets the primary color and an action type to a light
    Important: 
        This function changes the current color and action type stored in the active state
        since the last LFX_Reset() call. It does NOT immediately update the physical light
        settings, until a call to LFX_Update() is made. If the action type is a morph, then 
        the secondary color for the action is black.
    Inputs:	Accepts an index to the device, an index to the light, an action type, and a new primary LFX_COLOR value
    Outputs: None
    /// <returns> 
        LFX_ERROR_NOINIT if the system is not yet initialized.
        LFX_FAILURE or LFX_SUCCESS otherwise.
    /// <summary>
    [DllImport("LightFX.dll")]        public static extern LFX_Result LFX_SetLightActionColor(const unsigned int, const unsigned int, const unsigned int, const PLFX_COLOR);

    /// <summary>
    Function: LFX_SetLightActionColorEx
    Description:
        Sets the primary and secondary colors and an action type to a light
    Important: 
        This function changes the current color and action type stored in the active state
        since the last LFX_Reset() call. It does NOT immediately update the physical light
        settings, until a call to LFX_Update() is made. If the action type is not a morph, 
        then the secondary color is ignored.
    Inputs:	Accepts an index to the device, an index to the light, an action type, and two LFX_COLOR values
    Outputs: None
    /// <returns> 
        LFX_ERROR_NOINIT if the system is not yet initialized.
        LFX_FAILURE or LFX_SUCCESS otherwise.
    /// <summary>
    [DllImport("LightFX.dll")]        public static extern LFX_Result LFX_SetLightActionColorEx(const unsigned int, const unsigned int, const unsigned int, const PLFX_COLOR, const PLFX_COLOR);

    /// <summary>
    Function: LFX_ActionColor
    Description:
        Sets the primary color and an action type for any devices with lights in a location.
    Important: 
        This function changes the current primary color and action type stored in the active state
        since the last LFX_Reset() call. It does NOT immediately update the physical light
        settings, until a call to LFX_Update() is made. If the action type is a morph, then 
        the secondary color for the action is black.
    Location Mask Note: 
        Location mask is a 32-bit field, where each of the first 27 bits represent 
        a zone in the virtual cube representing the system (see LFXDecl.h)
    Color Packing Note: 
        Color is packed into a 32-bit value, as follows:
            Bits 0-7: Blue
            Bits 8-15: Green
            Bits 16-23: Red
            Bits 24-32: Brightness
    Inputs:	Accepts a 32-bit location mask and a packed color value
    Outputs: None
    /// <returns> 
        LFX_ERROR_NOINIT if the system is not yet initialized.
        LFX_ERROR_NOLIGHTS if no lights were found at the location mask specified.
        LFX_FAILURE if some other error occurred 
        LFX_SUCCESS otherwise.
    /// <summary>
    [DllImport("LightFX.dll")]        public static extern LFX_Result LFX_ActionColor(const unsigned int, const unsigned int, const unsigned int);

    /// <summary>
    Function: LFX_ActionColorEx
    Description:
        Sets the primary and secondary color and an action type for any devices with lights in a location.
    Important: 
        This function changes the current primary and secondary color and action type stored in the active state
        since the last LFX_Reset() call. It does NOT immediately update the physical light
        settings, until a call to LFX_Update() is made. If the action type is not a morph, 
        then the secondary color is ignored.
    Location Mask Note: 
        Location mask is a 32-bit field, where each of the first 27 bits represent 
        a zone in the virtual cube representing the system (see LFXDecl.h)
    Color Packing Note: 
        Color is packed into a 32-bit value, as follows:
            Bits 0-7: Blue
            Bits 8-15: Green
            Bits 16-23: Red
            Bits 24-32: Brightness
    Inputs:	Accepts a 32-bit location mask and a packed color value
    Outputs: None
    /// <returns> 
        LFX_ERROR_NOINIT if the system is not yet initialized.
        LFX_ERROR_NOLIGHTS if no lights were found at the location mask specified.
        LFX_FAILURE if some other error occurred 
        LFX_SUCCESS otherwise.
    /// <summary>
    [DllImport("LightFX.dll")]        public static extern LFX_Result LFX_ActionColorEx(const unsigned int, const unsigned int, const unsigned int, const unsigned int);








***/
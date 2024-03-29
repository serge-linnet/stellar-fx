﻿using RGB.NET.Core;

namespace StellarFx.Plugins.Artemis
{
    internal static class KeyboardIdMapping
    {
        internal static readonly Dictionary<LedId, LightFxKeyboardLedId> Default = new Dictionary<LedId, LightFxKeyboardLedId>
        {
            { LedId.Keyboard_Escape, LightFxKeyboardLedId.Esc },
            { LedId.Keyboard_F1, LightFxKeyboardLedId.F1},
            { LedId.Keyboard_F2, LightFxKeyboardLedId.F2},
            { LedId.Keyboard_F3, LightFxKeyboardLedId.F3 },
            { LedId.Keyboard_F4, LightFxKeyboardLedId.F4 },
            { LedId.Keyboard_F5, LightFxKeyboardLedId.F5 },
            { LedId.Keyboard_F6, LightFxKeyboardLedId.F6 },
            { LedId.Keyboard_F7, LightFxKeyboardLedId.F7 },
            { LedId.Keyboard_F8, LightFxKeyboardLedId.F8 },
            { LedId.Keyboard_F9, LightFxKeyboardLedId.F9 },
            { LedId.Keyboard_F10, LightFxKeyboardLedId.F10 },
            { LedId.Keyboard_F11, LightFxKeyboardLedId.F11 },
            { LedId.Keyboard_F12, LightFxKeyboardLedId.F12 },
            { LedId.Keyboard_Num7, LightFxKeyboardLedId.NUM_7 },
            { LedId.Keyboard_Num1, LightFxKeyboardLedId.NUM_1 },
            { LedId.Keyboard_NumComma, LightFxKeyboardLedId.NUM_DECIMAL },
            { LedId.Keyboard_GraveAccentAndTilde, LightFxKeyboardLedId.GraveAccentAndTilde },
            { LedId.Keyboard_1, LightFxKeyboardLedId.N1 },
            { LedId.Keyboard_2, LightFxKeyboardLedId.N2 },
            { LedId.Keyboard_3, LightFxKeyboardLedId.N3 },
            { LedId.Keyboard_4, LightFxKeyboardLedId.N4 },
            { LedId.Keyboard_5, LightFxKeyboardLedId.N5 },
            { LedId.Keyboard_6, LightFxKeyboardLedId.N6 },
            { LedId.Keyboard_7, LightFxKeyboardLedId.N7 },
            { LedId.Keyboard_8, LightFxKeyboardLedId.N8 },
            { LedId.Keyboard_9, LightFxKeyboardLedId.N9 },
            { LedId.Keyboard_0, LightFxKeyboardLedId.N0 },
            { LedId.Keyboard_MinusAndUnderscore, LightFxKeyboardLedId.Minus },
            { LedId.Keyboard_EqualsAndPlus, LightFxKeyboardLedId.Equals },
            { LedId.Keyboard_Backspace, LightFxKeyboardLedId.Backspace },
            { LedId.Keyboard_Custom1, LightFxKeyboardLedId.Mic },
            { LedId.Keyboard_Tab, LightFxKeyboardLedId.Tab },
            { LedId.Keyboard_Q, LightFxKeyboardLedId.Q },
            { LedId.Keyboard_W, LightFxKeyboardLedId.W },
            { LedId.Keyboard_E, LightFxKeyboardLedId.E },
            { LedId.Keyboard_R, LightFxKeyboardLedId.R },
            { LedId.Keyboard_T, LightFxKeyboardLedId.T },
            { LedId.Keyboard_Y, LightFxKeyboardLedId.Y },
            { LedId.Keyboard_U, LightFxKeyboardLedId.U },
            { LedId.Keyboard_I, LightFxKeyboardLedId.I },
            { LedId.Keyboard_O, LightFxKeyboardLedId.O },
            { LedId.Keyboard_P, LightFxKeyboardLedId.P },
            { LedId.Keyboard_BracketLeft, LightFxKeyboardLedId.BracketLeft },
            { LedId.Keyboard_BracketRight, LightFxKeyboardLedId.BracketRight },
            { LedId.Keyboard_Backslash, LightFxKeyboardLedId.Backslash },
            { LedId.Keyboard_MediaMute, LightFxKeyboardLedId.MediaMute },
            { LedId.Keyboard_CapsLock, LightFxKeyboardLedId.CapsLock },
            { LedId.Keyboard_A, LightFxKeyboardLedId.A },
            { LedId.Keyboard_S, LightFxKeyboardLedId.S },
            { LedId.Keyboard_D, LightFxKeyboardLedId.D },
            { LedId.Keyboard_F, LightFxKeyboardLedId.F },
            { LedId.Keyboard_G, LightFxKeyboardLedId.G },
            { LedId.Keyboard_H, LightFxKeyboardLedId.H },
            { LedId.Keyboard_J, LightFxKeyboardLedId.J },
            { LedId.Keyboard_K, LightFxKeyboardLedId.K },
            { LedId.Keyboard_L, LightFxKeyboardLedId.L },
            { LedId.Keyboard_SemicolonAndColon, LightFxKeyboardLedId.Semicolon },
            { LedId.Keyboard_ApostropheAndDoubleQuote, LightFxKeyboardLedId.ApostropheAndDoubleQuote },
            { LedId.Keyboard_Enter, LightFxKeyboardLedId.Enter },
            { LedId.Keyboard_MediaVolumeUp, LightFxKeyboardLedId.MediaVolumeUp },
            { LedId.Keyboard_LeftShift, LightFxKeyboardLedId.LeftShift },
            { LedId.Keyboard_Z, LightFxKeyboardLedId.Z },
            { LedId.Keyboard_X, LightFxKeyboardLedId.X },
            { LedId.Keyboard_C, LightFxKeyboardLedId.C },
            { LedId.Keyboard_V, LightFxKeyboardLedId.V },
            { LedId.Keyboard_B, LightFxKeyboardLedId.B },
            { LedId.Keyboard_N, LightFxKeyboardLedId.N },
            { LedId.Keyboard_M, LightFxKeyboardLedId.M },
            { LedId.Keyboard_CommaAndLessThan, LightFxKeyboardLedId.CommaAndLessThan },
            { LedId.Keyboard_PeriodAndBiggerThan, LightFxKeyboardLedId.PeriodAndBiggerThan},
            { LedId.Keyboard_SlashAndQuestionMark, LightFxKeyboardLedId.SlashAndQuestionMark },
            { LedId.Keyboard_RightShift, LightFxKeyboardLedId.RightShift },
            { LedId.Keyboard_Num8, LightFxKeyboardLedId.NUM_8 },
            { LedId.Keyboard_MediaVolumeDown, LightFxKeyboardLedId.MediaVolumeDown },
            { LedId.Keyboard_LeftCtrl, LightFxKeyboardLedId.LeftCtrl },
            { LedId.Keyboard_Function, LightFxKeyboardLedId.Fn },
            { LedId.Keyboard_LeftGui, LightFxKeyboardLedId.Windows },
            { LedId.Keyboard_LeftAlt, LightFxKeyboardLedId.LeftAlt },
            { LedId.Keyboard_RightAlt, LightFxKeyboardLedId.RightAlt },
            { LedId.Keyboard_WinLock, LightFxKeyboardLedId.WinLock },
            { LedId.Keyboard_RightCtrl, LightFxKeyboardLedId.RightCtrl },
            { LedId.Keyboard_Num4, LightFxKeyboardLedId.NUM_4 },
            { LedId.Keyboard_Num2, LightFxKeyboardLedId.NUM_2},
            { LedId.Keyboard_Num6, LightFxKeyboardLedId.NUM_6}
        };
    }
}
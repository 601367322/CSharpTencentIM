using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using static com.tencent.imsdk.unity.native.IMNativeSDK;

namespace WpfApp1
{
    class Class1
    {
        [DllImport("ImSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TIMLogout(CommonValueCallback cb, IntPtr user_data);

        [DllImport("ImSDK.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TIMGetLoginStatus();
    }
}

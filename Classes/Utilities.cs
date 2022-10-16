using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Left4Sharp_Remastered.Classes
{
    public static class Utilities
    {
        public static int GetModuleByName(string moduleName)
        {
            foreach (ProcessModule module in Process.GetCurrentProcess().Modules)
            {
                if (module.ModuleName == moduleName)
                    return (Int32)module.BaseAddress;
            }

            return 0;
        }

        public static int GetModuleAddress(this string moduleName)
        {
            foreach (ProcessModule module in Process.GetCurrentProcess().Modules)
            {
                if (module.ModuleName == moduleName)
                    return (Int32)module.BaseAddress;
            }

            return 0;
        }

        public static unsafe IntPtr VTable(this IntPtr addr, int index)
        {
            //var pAddr = (void***)addr.ToPointer();
            return ((*(IntPtr**)addr)[index]);
        }


        public static T GetVirtualFunction<T>(IntPtr classAddress, int functionIndex) where T : class
        {
            return Marshal.GetDelegateForFunctionPointer<T>(classAddress.VTable(functionIndex));
        }

        public static bool IsKeyPushedDown(System.Windows.Forms.Keys vKey)
        {
            return 0 != (Win32.GetAsyncKeyState(vKey) & 0x8000);
        }
    }
}

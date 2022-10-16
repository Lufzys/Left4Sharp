using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Left4Sharp_Remastered.Classes
{
    internal class InterfaceManager
    {
        delegate IntPtr DelCreateInterface(string interfaceName, out int returnCode);

        public static IntPtr GetInterface(string moduleName, string interfaceName)
        {
            IntPtr interfaceFuncAddr = Win32.GetProcAddress((IntPtr)moduleName.GetModuleAddress(), "CreateInterface");
            DelCreateInterface interfaceFunc = (DelCreateInterface)Marshal.GetDelegateForFunctionPointer(interfaceFuncAddr, typeof(DelCreateInterface));
            return interfaceFunc(interfaceName, out int zero);
        }
    }
}

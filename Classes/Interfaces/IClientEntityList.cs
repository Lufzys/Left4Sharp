using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Left4Sharp_Remastered.Classes.Interfaces
{
    public class IClientEntityList
    {
        public static IntPtr Address = IntPtr.Zero;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate IntPtr DelGetClientNetworkable(IntPtr ptr, int entnum);
        public static DelGetClientNetworkable _GetClientNetworkable;
        public static readonly int GetClientNetworkable_Index = 0;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate IntPtr DelGetClientNetworkableFromHandle(IntPtr ptr, IntPtr hEnt);
        public static DelGetClientNetworkableFromHandle _GetClientNetworkableFromHandle;
        public static readonly int GetClientNetworkableFromHandle_Index = 1;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate IntPtr DelGetClientUnknownFromHandle(IntPtr ptr, IntPtr hEnt);
        public static DelGetClientUnknownFromHandle _GetClientUnknownFromHandle;
        public static readonly int GetClientUnknownFromHandle_Index = 2;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate IntPtr DelGetClientEntity(IntPtr ptr, int entnum);
        public static DelGetClientEntity _GetClientEntity;
        public static readonly int GetClientEntity_Index = 3;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate IntPtr DelGetClientEntityFromHandle(IntPtr ptr, IntPtr hEnt);
        public static DelGetClientEntityFromHandle _GetClientEntityFromHandle;
        public static readonly int GetClientEntityFromHandle_Index = 4;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate int DelNumberOfEntities(IntPtr ptr, bool bIncludeNonNetworkable);
        public static DelNumberOfEntities _NumberOfEntities;
        public static readonly int NumberOfEntities_Index = 5;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate int DelGetHighestEntityIndex(IntPtr ptr);
        public static DelGetHighestEntityIndex _GetHighestEntityIndex;
        public static readonly int GetHighestEntityIndex_Index = 6;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate void DelSetMaxEntities(IntPtr ptr, int maxents);
        public static DelSetMaxEntities _SetMaxEntities;
        public static readonly int SetMaxEntities_Index = 7;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate int DelGetMaxEntities(IntPtr ptr);
        public static DelGetMaxEntities _GetMaxEntities;
        public static readonly int GetMaxEntities_Index = 8;

        public static void SetupInterface(IntPtr address)
        {
            Address = address;

            _GetClientNetworkable = Utilities.GetVirtualFunction<DelGetClientNetworkable>(Address, GetClientNetworkable_Index);
            _GetClientNetworkableFromHandle = Utilities.GetVirtualFunction<DelGetClientNetworkableFromHandle>(Address, GetClientNetworkableFromHandle_Index);
            _GetClientUnknownFromHandle = Utilities.GetVirtualFunction<DelGetClientUnknownFromHandle>(Address, GetClientUnknownFromHandle_Index);
            _GetClientEntity = Utilities.GetVirtualFunction<DelGetClientEntity>(Address, GetClientEntity_Index);
            _GetClientEntityFromHandle = Utilities.GetVirtualFunction<DelGetClientEntityFromHandle>(Address, GetClientEntityFromHandle_Index);
            _NumberOfEntities = Utilities.GetVirtualFunction<DelNumberOfEntities>(Address, NumberOfEntities_Index);
            _GetHighestEntityIndex = Utilities.GetVirtualFunction<DelGetHighestEntityIndex>(Address, GetHighestEntityIndex_Index);
            _SetMaxEntities = Utilities.GetVirtualFunction<DelSetMaxEntities>(Address, SetMaxEntities_Index);
            _GetMaxEntities = Utilities.GetVirtualFunction<DelGetMaxEntities>(Address, GetMaxEntities_Index);
        }


        public static IntPtr GetClientNetworkable(int entnum)
        {
            return _GetClientNetworkable(Address, entnum);
        }

        public static IntPtr GetClientNetworkableFromHandle(IntPtr hEnt)
        {
            return _GetClientNetworkableFromHandle(Address, hEnt);
        }

        public static IntPtr GetClientUnknownFromHandle(IntPtr hEnt)
        {
            return _GetClientUnknownFromHandle(Address, hEnt);
        }

        public static IntPtr GetClientEntity(int entnum)
        {
            return _GetClientEntity(Address, entnum);
        }

        public static IntPtr GetClientEntityFromHandle(IntPtr hEnt)
        {
            return _GetClientEntityFromHandle(Address, hEnt);
        }

        public static int NumberOfEntities(bool bIncludeNonNetworkable)
        {
            return _NumberOfEntities(Address, bIncludeNonNetworkable);
        }

        public static int GetHighestEntityIndex()
        {
            return _GetHighestEntityIndex(Address);
        }

        public static void SetMaxEntities(int maxents)
        {
            _SetMaxEntities(Address, maxents);
        }

        public static int GetMaxEntities()
        {
            return _GetMaxEntities(Address);
        }
    }
}

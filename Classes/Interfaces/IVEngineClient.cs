using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Left4Sharp_Remastered.Classes.Interfaces.IVEngineClient;

namespace Left4Sharp_Remastered.Classes.Interfaces
{
    class IVEngineClient
    {
        public static IntPtr Address = IntPtr.Zero;

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct player_info_t
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public char[] __pad0;
            public int m_nXuidLow;
            public int m_nXuidHigh;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
            public char[] m_szPlayerName;
            public int m_nUserID;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
            public char[] m_szSteamID;
            public uint m_nSteam3ID;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
            public char[] m_szFriendsName;
            [MarshalAs(UnmanagedType.U1, SizeConst = 1)]
            public bool m_bIsFakePlayer;
            [MarshalAs(UnmanagedType.U1, SizeConst = 1)]
            public bool m_bIsHLTV;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public int[] m_dwCustomFiles;
            public char m_FilesDownloaded;
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate void DelGetScreenSize(IntPtr ptr, ref int width, ref int height);
        public static DelGetScreenSize _GetScreenSize;
        public static readonly int GetScreenSize_Index = 5;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate void DelClientCmd(IntPtr ptr, string szCmdString);
        public static DelClientCmd _ClientCmd;
        public static readonly int ClientCmd_Index = 7;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate bool DelGetPlayerInfo(IntPtr ptr, int ent_num, ref player_info_t pinfo);
        public static DelGetPlayerInfo _GetPlayerInfo;
        public static readonly int GetPlayerInfo_Index = 8;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate int DelGetLocalPlayer(IntPtr ptr);
        public static DelGetLocalPlayer _GetLocalPlayer;
        public static readonly int GetLocalPlayer_Index = 12;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate void DelGetViewAngles(IntPtr ptr, ref Vector3 va);
        public static DelGetViewAngles _GetViewAngles;
        public static readonly int GetViewAngles_Index = 19;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate void DelSetViewAngles(IntPtr ptr, ref Vector3 va);
        public static DelSetViewAngles _SetViewAngles;
        public static readonly int SetViewAngles_Index = 20;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate bool DelIsInGame(IntPtr ptr);
        public static DelIsInGame _IsInGame;
        public static readonly int IsInGame_Index = 26;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate bool DelIsConnected(IntPtr ptr);
        public static DelIsConnected _IsConnected;
        public static readonly int IsConnected_Index = 27;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate void DelCon_NPrintf(IntPtr ptr, int pos, string fmt);
        public static DelCon_NPrintf _Con_NPrintf;
        public static readonly int Con_NPrintf_Index = 29;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate ref Matrix4x4 DelWorldToScreenMatrix(IntPtr ptr);
        public static DelWorldToScreenMatrix _WorldToScreenMatrix;
        public static readonly int WorldToScreenMatrix_Index = 36;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate IntPtr DelGetMapEntitiesString(IntPtr ptr);
public static DelGetMapEntitiesString _GetMapEntitiesString;
public static readonly int GetMapEntitiesString_Index = 86;

        public static void SetupInterface(IntPtr address)
        {
            Address = address;

            _GetScreenSize = Utilities.GetVirtualFunction<DelGetScreenSize>(Address, GetScreenSize_Index);
            _ClientCmd = Utilities.GetVirtualFunction<DelClientCmd>(Address, ClientCmd_Index);
            _GetPlayerInfo = Utilities.GetVirtualFunction<DelGetPlayerInfo>(Address, GetPlayerInfo_Index);
            _GetLocalPlayer = Utilities.GetVirtualFunction<DelGetLocalPlayer>(Address, GetLocalPlayer_Index);
            _GetViewAngles = Utilities.GetVirtualFunction<DelGetViewAngles>(Address, GetViewAngles_Index);
            _SetViewAngles = Utilities.GetVirtualFunction<DelSetViewAngles>(Address, SetViewAngles_Index);
            _IsInGame = Utilities.GetVirtualFunction<DelIsInGame>(Address, IsInGame_Index);
            _IsConnected = Utilities.GetVirtualFunction<DelIsConnected>(Address, IsConnected_Index);
            _Con_NPrintf = Utilities.GetVirtualFunction<DelCon_NPrintf>(Address, Con_NPrintf_Index);
            _WorldToScreenMatrix = Utilities.GetVirtualFunction<DelWorldToScreenMatrix>(Address, WorldToScreenMatrix_Index);
            _GetMapEntitiesString = Utilities.GetVirtualFunction<DelGetMapEntitiesString>(Address, GetMapEntitiesString_Index);
        }

        public static void GetScreenSize(ref int width, ref int height)
        {
            _GetScreenSize(Address, ref width, ref height);
        }

        public static void ClientCmd(string szCmdString)
        {
            _ClientCmd(Address, szCmdString);
        }

        public static bool GetPlayerInfo(int ent_num, ref player_info_t pinfo)
        {
            return _GetPlayerInfo(Address, ent_num, ref pinfo);
        }

        public static int GetLocalPlayer()
        {
            return _GetLocalPlayer(Address);
        }

        public static void GetViewAngles(ref Vector3 va)
        {
            _GetViewAngles(Address, ref va);
        }

        public static void SetViewAngles(ref Vector3 va)
        {
            _SetViewAngles(Address, ref va);
        }

        public static bool IsInGame()
        {
            return _IsInGame(Address);
        }

        public static bool IsConnected()
        {
            return _IsConnected(Address);
        }

        public static void Con_NPrintf(int pos, string fmt)
        {
            _Con_NPrintf(Address, pos, fmt);
        }

        public static Matrix4x4 WorldToScreenMatrix()
        {
            return _WorldToScreenMatrix(Address);
        }

        public static IntPtr GetMapEntitiesString()
        {
            return _GetMapEntitiesString(Address);
        }
    }
}
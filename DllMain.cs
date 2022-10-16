using Left4Sharp_Remastered.Classes;
using Left4Sharp_Remastered.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Left4Sharp_Remastered
{
    public class DllMain
    {
        [DllExport("EntryPoint")]
        public static void EntryPoint()
        {
            Win32.AllocConsole();

            while ("client.dll".GetModuleAddress() == 0) { Thread.Sleep(500); }
            while ("engine.dll".GetModuleAddress() == 0) { Thread.Sleep(500); }

            Thread thMain = new Thread(new ThreadStart(MainThread));
            thMain.Priority = ThreadPriority.Highest;
            thMain.IsBackground = true;
            thMain.Start();
        }

        public unsafe static void MainThread()
        {
            IClientEntityList.SetupInterface(InterfaceManager.GetInterface("client.dll", "VClientEntityList003"));
            IVEngineClient.SetupInterface(InterfaceManager.GetInterface("engine.dll", "VEngineClient013"));

            while (true)
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Highest Entity Index => " + IClientEntityList.GetHighestEntityIndex());
                Console.WriteLine("LocalPlayer Address => 0x" + IClientEntityList.GetClientEntity(IVEngineClient.GetLocalPlayer()).ToString("X"));

                IVEngineClient.player_info_t player_info = default;
                IVEngineClient.GetPlayerInfo(IVEngineClient.GetLocalPlayer(), ref player_info);
                Console.WriteLine("Player Name => " + new string(player_info.m_szPlayerName));
                Console.WriteLine("Is Connected => " + IVEngineClient.IsConnected().ToString());
                Vector3 viewAngles = new Vector3();
                IVEngineClient.GetViewAngles(ref viewAngles);
                Console.WriteLine("ViewAngles => " + viewAngles.ToString());
                Console.WriteLine("-------------------------------------------");

                if(Utilities.IsKeyPushedDown(System.Windows.Forms.Keys.Insert))
                {
                    IVEngineClient.ClientCmd("say c++ for idiots");
                }
                Thread.Sleep(100);
            }
        }
    }
}

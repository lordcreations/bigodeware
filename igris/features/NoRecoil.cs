using System;
using System.Threading;
using Swed64;
using igris.modules;
using System.Timers;
using static System.Net.Mime.MediaTypeNames;
using System.Numerics;

namespace igris.features
{
    public static class No_Recoil
    {
        private static Swed swed = new Swed("cs2");
        private static nint clientcs = swed.GetModuleBase("client.dll");
        private static Offsets offsets = Offsets.Instance;

        public static void Run()
        {
            Log.Info("NoRecoil feature started.");
            while (true)
            {
                try
                {
                    IntPtr localPlayer = swed.ReadPointer(clientcs + offsets.Offset("dwLocalPlayerPawn"));
                    var AimPunchCache = swed.ReadPointer(localPlayer + offsets.Client("C_CSPlayerPawn", "m_aimPunchAngle"));
                    //Console.WriteLine($"AimPunchCache: {AimPunchCache}");
                }
                catch (Exception e)
                {
                    Log.Error($"NoRecoil feature encountered an error: {e.Message}");
                }

            }
        }
    }
}

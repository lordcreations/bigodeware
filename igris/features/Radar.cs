using System;
using System.Threading;
using Swed64;
using igris.modules;
using System.Timers;
using static System.Net.Mime.MediaTypeNames;

namespace igris.features
{
    public static class Radar
    {
        private static Swed swed = new Swed("cs2");
        private static nint clientcs = swed.GetModuleBase("client.dll");
        private static Offsets offsets = Offsets.Instance;

        /// <summary>
        /// Starts the Radar feature in a separate thread.
        /// </summary>
        public static void Run()
        {
            Log.Info("Radar feature started.");
            while (true)
            {
                try
                {
                    IntPtr entityList = swed.ReadPointer(clientcs, offsets.Offset("dwEntityList"));
                    IntPtr ListEntry = swed.ReadPointer(entityList, 0x10);
                    for (int i = 0; i < 64; i++)
                    {
                        if (ListEntry == IntPtr.Zero) continue;

                        IntPtr currentController = swed.ReadPointer(ListEntry, i * 0x78);
                        if (currentController == IntPtr.Zero) continue;

                        bool m_bPawnIsAlive = swed.ReadBool(currentController + offsets.Client("CCSPlayerController", "m_bPawnIsAlive"));
                        if (!m_bPawnIsAlive) continue;

                        int pawnHandle = swed.ReadInt(currentController, offsets.Client("CCSPlayerController", "m_hPlayerPawn"));
                        if (pawnHandle == 0) continue;

                        IntPtr listEntry2 = swed.ReadPointer(entityList, 0x8 * ((pawnHandle & 0x7FFF) >> 9) + 0x10);
                        IntPtr currentPawn = swed.ReadPointer(listEntry2, 0x78 * (pawnHandle & 0x1FF));
                        if (currentPawn == IntPtr.Zero) continue;

                        swed.WriteBool(currentPawn + offsets.Client("C_CSPlayerPawn", "m_entitySpottedState") + offsets.Client("EntitySpottedState_t", "m_bSpotted"), true);
                    }
                }
                catch (Exception e)
                {
                    Log.Error($"Radar feature encountered an error: {e.Message}");
                }
                
            }
        }
    }
}

using System;
using System.Threading;
using Swed64;
using igris.modules;
using System.Timers;
using static System.Net.Mime.MediaTypeNames;

namespace igris.features
{
    public static class C4_timer
    {
        private static Swed swed = new Swed("cs2");
        private static nint clientcs = swed.GetModuleBase("client.dll");
        private static Offsets offsets = Offsets.Instance;

        /// <summary>
        /// Starts the C4Timer feature in a separate thread.
        /// </summary>
        public static void Run()
        {
            Log.Info("C4Timer feature started.");
            while (true)
            {
                try
                {
                    bool isPlanted = swed.ReadBool(clientcs + offsets.Offset("dwPlantedC4") - 0x8);
                    IntPtr global_vars = swed.ReadPointer(clientcs + offsets.Offset("dwGlobalVars"));
                    float time = swed.ReadFloat(global_vars);
                    if (isPlanted)
                    {

                        IntPtr planted_c4 = swed.ReadPointer(swed.ReadPointer(clientcs + offsets.Offset("dwPlantedC4")));
                        float bomb_time = swed.ReadFloat(planted_c4 + offsets.Client("C_PlantedC4", "m_flC4Blow"));

                        //float bomb_timer = bomb_time - time;
                        float bomb_timer = (bomb_time - time) - 3.0f;
                        if (bomb_timer < 0) continue;
                        //Log.Success($"Time left: {bomb_timer:F2}s");
                        Console.Title = $"Time left: {bomb_timer:F2}s";
                    }
                    else
                    {
                        Console.Title = "C4 not planted";
                    }
                }
                catch (Exception e)
                {
                    Log.Error($"C4Timer feature encountered an error: {e.Message}");
                }

                Thread.Sleep(100); // Update every 100ms for accurate timing
            }
        }
    }
}

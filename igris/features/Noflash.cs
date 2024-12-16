using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using igris.modules;
using Swed64;

namespace bigodeware.features
{
    internal class No_flash
    {
        private static Swed swed = new Swed("cs2");
        private static nint clientcs = swed.GetModuleBase("client.dll");
        private static Offsets offsets = Offsets.Instance;

        public static void Run()
        {
            Log.Info("No_flash feature started.");
            while (true)
            {
                try
                {
                    IntPtr localPlayer = swed.ReadPointer(clientcs + offsets.Offset("dwLocalPlayerPawn"));
                    var FlashMaxAlpha = swed.ReadFloat(localPlayer + offsets.Client("C_CSPlayerPawnBase", "m_flFlashMaxAlpha"));
                    if (FlashMaxAlpha > 0.0f)
                    {
                        swed.WriteFloat(localPlayer + offsets.Client("C_CSPlayerPawnBase", "m_flFlashMaxAlpha"), 0.0f);
                    }
                }
                catch (Exception e)
                {
                    Log.Error($"No_flash feature encountered an error: {e.Message}");
                }
            }
        }
    }
}

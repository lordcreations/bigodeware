using System;
using System.Threading;
using Swed64;
using igris.modules;
using System.Timers;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.InteropServices;

namespace igris.features
{
    public static class Bhop
    {
        private static Swed swed = new Swed("cs2");
        private static nint clientcs = swed.GetModuleBase("client.dll");
        private static Offsets offsets = Offsets.Instance;
        private const uint MOUSEEVENTF_WHEEL = 0x0800;


        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, int dwData, UIntPtr dwExtraInfo);
        /// <summary>
        /// Starts the Bhop feature in a separate thread.
        /// </summary>
        public static void Run()
        {
            const int SPACEBAR = 0x20;
            //const int STANDING = 65665;
            //const int CROUNCHING = 65667;
            //const int IN_AIR = 65664;
            //const int PLUS_JUMP = 65537;
            //const int MINUS_JUMP = 256;
            Log.Info("Bhop feature started.");
            int count = 0;
            while (true)
            {
                try
                {

                    IntPtr playerPawnAddress = swed.ReadPointer(clientcs + offsets.Offset("dwLocalPlayerPawn"));
                    if (playerPawnAddress == IntPtr.Zero) continue;
                    uint fFlag = swed.ReadUInt(playerPawnAddress, offsets.Client("C_BaseEntity", "m_fFlags"));


                    if ((GetAsyncKeyState(SPACEBAR) & 0x8000) != 0 && (fFlag & ((uint)(1 << 0))) != 0)
                    {
                        mouse_event(MOUSEEVENTF_WHEEL, 0, 0, -120, UIntPtr.Zero);
                        Thread.Sleep(15);
                        mouse_event(MOUSEEVENTF_WHEEL, 0, 0, 120, UIntPtr.Zero);
                    }
                }
                catch (Exception e)
                {
                    Log.Error($"C4Timer feature encountered an error: {e.Message}");
                }
            }
        }
    }
}

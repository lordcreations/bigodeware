using igris.modules;
using igris.features;
using System.Runtime.InteropServices;
using Swed64;
using System.Diagnostics;
using bigodeware.features;

namespace igris
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);
        static void Main(string[] args)
        {
            try
            {
                Log.Info("Starting the application...");
                Process[] processes = Process.GetProcessesByName("cs2");
                if (processes.Length == 0)
                {
                    Log.Error("Please start the game before running the application.");
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadLine();
                    return;
                }

                var offsets = Offsets.Instance;

                //var skin_changer_thread = new Thread(Skin_changer.Run);
                //var c4_timer_thread = new Thread(C4_timer.Run);
                //var jump_shot_thread = new Thread(Jump_shot.Run);
                //var trigger_thread = new Thread(Trigger.Run);
                //var radar_thread = new Thread(Radar.Run);
                var bhop_thread = new Thread(Bhop.Run);
                //var no_recoil_thread = new Thread(No_Recoil.Run);
                //var no_flash_thread = new Thread(No_flash.Run);

                //skin_changer_thread.Start();
                //c4_timer_thread.Start();
                //jump_shot_thread.Start();
                //trigger_thread.Start();
                //radar_thread.Start();
                bhop_thread.Start();
                //no_recoil_thread.Start();
                //No_flash.Run();

                //skin_changer_thread.Join();
                //c4_timer_thread.Join();
                //jump_shot_thread.Join();
                //trigger_thread.Join();
                //radar_thread.Join();
                bhop_thread.Join();
                //no_recoil_thread.Join();
                //no_flash_thread.Join();


            }
            catch
            {
                Log.Error("An error occurred while starting the application.");
            }
        }
    }
}

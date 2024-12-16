using System;
using System.Threading;
using Swed64;
using igris.modules;
using System.Numerics;
using System.Runtime.InteropServices;

namespace igris.features
{
    public static class Jump_shot
    {
        private static Swed swed = new Swed("cs2");
        private static nint clientcs = swed.GetModuleBase("client.dll");
        private static Offsets offsets = Offsets.Instance;

        public static void Run()
        {
            Log.Info("JumpShot feature started.");

            const int IN_AIR = 65664;
            const int HOTKEY = 0x06; // Mouse 4
            const int TARGET_WEAPON_INDEX = 40; // SSG08
            const int PLUS = 65537;
            const int MINUS = 256;

            while (true)
            {
                try
                {
                    // Get the local player pawn
                    IntPtr pawnAddress = swed.ReadPointer(clientcs + offsets.Offset("dwLocalPlayerPawn"));
                    if (pawnAddress == IntPtr.Zero) continue;

                    // Get the equipped weapon
                    IntPtr weaponAddress = swed.ReadPointer(pawnAddress + offsets.Client("C_CSPlayerPawnBase", "m_pClippingWeapon"));
                    short weaponDefinitionIndex = swed.ReadShort(
                        weaponAddress,
                        offsets.Client("C_EconEntity", "m_AttributeManager") +
                        offsets.Client("C_AttributeContainer", "m_Item") +
                        offsets.Client("C_EconItemView", "m_iItemDefinitionIndex")
                    );

                    //Log.Info($"Weapon Definition Index: {weaponDefinitionIndex}");

                    if (weaponDefinitionIndex == -1 || weaponDefinitionIndex != TARGET_WEAPON_INDEX) continue;

                    int fFlag = swed.ReadInt(pawnAddress + offsets.Client("C_BaseEntity", "m_fFlags"));

                    if (fFlag == IN_AIR && GetAsyncKeyState(HOTKEY) < 0)
                    {
                        Thread.Sleep(10);

                        // Continuously check velocity while the player is in the air
                        Vector3 velocity = swed.ReadVec(pawnAddress + offsets.Client("C_BaseEntity", "m_vecAbsVelocity"));
                        while (velocity.Z > 18f || velocity.Z < -18f)
                        {
                            Thread.Sleep(10);
                            velocity = swed.ReadVec(pawnAddress + offsets.Client("C_BaseEntity", "m_vecAbsVelocity"));
                        }

                        // Trigger the jump shot action
                        swed.WriteInt(clientcs + offsets.Buttons("attack"), PLUS);
                        Thread.Sleep(15); // Simulate click duration
                        swed.WriteInt(clientcs + offsets.Buttons("attack"), MINUS);
                        Thread.Sleep(100);
                    }
                }
                catch (Exception e)
                {
                    Log.Error($"JumpShot feature encountered an error: {e.Message}");
                }

                Thread.Sleep(2); // Small delay to prevent CPU overuse
            }
        }

        /// <summary>
        /// Detects the state of a key.
        /// </summary>
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);
    }
}

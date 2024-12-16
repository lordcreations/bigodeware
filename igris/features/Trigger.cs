using System;
using System.Threading;
using Swed64;
using igris.modules;
using System.Runtime.InteropServices;

namespace igris.features
{
    public static class Trigger
    {
        private static Swed swed = new Swed("cs2");
        private static nint client_cs = swed.GetModuleBase("client.dll");
        private static Offsets offsets = Offsets.Instance;
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);
        public static void Run()
        {
            Log.Info("Trigger feature started.");

            int[] target_weapon_indices = { 42, 59 };
            const int IN_AIR = 65664;
            const int HOTKEY = 0x05;

            while (true)
            {
                try
                {
                    IntPtr local_player = swed.ReadPointer(client_cs + offsets.Offset("dwLocalPlayerPawn"));
                    if (local_player == IntPtr.Zero) continue;

                    int fFlag = swed.ReadInt(local_player + offsets.Client("C_BaseEntity", "m_fFlags"));
                    if (fFlag == IN_AIR) continue;

                    IntPtr dwGlobalVars = swed.ReadPointer(client_cs + offsets.Offset("dwGlobalVars"));
                    int tick_count = swed.ReadInt(dwGlobalVars + 0x1C);


                    IntPtr weapon_address = swed.ReadPointer(local_player + offsets.Client("C_CSPlayerPawnBase", "m_pClippingWeapon"));
                    short weapon_definition_index = swed.ReadShort(
                        weapon_address,
                        offsets.Client("C_EconEntity", "m_AttributeManager") +
                        offsets.Client("C_AttributeContainer", "m_Item") +
                        offsets.Client("C_EconItemView", "m_iItemDefinitionIndex")
                    );

                    // Log.Info($"Weapon Id: {weapon_definition_index}");
                    int NextPrimaryAttackTick = swed.ReadInt(weapon_address + offsets.Client("C_BasePlayerWeapon", "m_nNextPrimaryAttackTick"));
                    if (weapon_definition_index == -1 || target_weapon_indices.Contains(weapon_definition_index)) continue;

                    IntPtr entityId = swed.ReadPointer(local_player + offsets.Client("C_CSPlayerPawnBase", "m_iIDEntIndex"));
                    if (entityId == IntPtr.Zero) continue;

                    IntPtr entity = GetEntity(entityId);
                    if (entity == IntPtr.Zero) continue;

                    int entity_team = swed.ReadInt(entity + offsets.Client("C_BaseEntity", "m_iTeamNum"));
                    int player_team = swed.ReadInt(local_player + offsets.Client("C_BaseEntity", "m_iTeamNum"));
                    int entity_health = swed.ReadInt(entity + offsets.Client("C_BaseEntity", "m_iHealth"));

                    if (entity_team == player_team || entity_health <= 0) continue;
                    if (NextPrimaryAttackTick > tick_count) continue;

                    if (entity_health > 0)
                    {
                        if (GetAsyncKeyState(HOTKEY) < 0)
                        {
                            trigger_action();
                        }
                    }
                }
                catch (Exception e)
                {
                    Log.Error($"Trigger feature encountered an error: {e.Message}");
                }

                Thread.Sleep(2);
            }
        }
        private static IntPtr GetEntity(IntPtr index)
        {
            IntPtr entityList = swed.ReadPointer(client_cs + offsets.Offset("dwEntityList"));
            if (entityList == IntPtr.Zero) return IntPtr.Zero;

            IntPtr entity_entry = swed.ReadPointer(entityList + 0x8 * ((int)index >> 9) + 0x10);
            return swed.ReadPointer(entity_entry+ 120 * ((int)index & 0x1FF));
        }

        private static void trigger_action()
        {
            const int PLUS = 65537;
            const int MINUS = 256;
            Thread.Sleep(5);
            swed.WriteInt(client_cs + offsets.Buttons("attack"), PLUS);
            Thread.Sleep(150); 
            swed.WriteInt(client_cs + offsets.Buttons("attack"), MINUS);
        }
    }

}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using igris.modules;
using Swed64;

namespace igris.features
{
    internal class Skin_changer
    {
        private static Swed swed = new Swed("cs2");
        private static nint clientcs = swed.GetModuleBase("client.dll");
        private static nint engine = swed.GetModuleBase("engine2.dll");

        private static Offsets offsets = Offsets.Instance;
        public static void set_weapon_skin(int weapon_id, int steam_id, IntPtr weapon, int paint_kit, int seed, float wear, string m_szCustomName, int stattrak, int quality, bool m_bDisallowSOC = false, int m_iItemIDHigh = -1)
        {
            try
            {
                if (weapon_id == 9)
                {
                    swed.WriteBool(weapon + offsets.Client("C_EconEntity", "m_bClientside"), true);
                    swed.WriteInt(weapon + offsets.Client("C_EconEntity", "m_nFallbackPaintKit"), paint_kit);
                    swed.WriteInt(weapon + offsets.Client("C_EconEntity", "m_nFallbackSeed"), seed);
                    swed.WriteInt(weapon + offsets.Client("C_EconEntity", "m_nFallbackStatTrak"), stattrak);
                    swed.WriteInt(weapon + offsets.Client("C_EconEntity", "m_iNumOwnerValidationRetries"), -1);
                    swed.WriteFloat(weapon + offsets.Client("C_EconEntity", "m_flFallbackWear"), wear);
                    swed.WriteString(weapon + offsets.Client("C_EconEntity", "m_AttributeManager") + offsets.Client("C_AttributeContainer", "m_Item") + offsets.Client("C_EconItemView", "m_szCustomName"), m_szCustomName);
                    swed.WriteInt(weapon + offsets.Client("C_EconEntity", "m_AttributeManager") + offsets.Client("C_AttributeContainer", "m_Item") + offsets.Client("C_EconItemView", "m_iEntityQuality"), quality);
                    swed.WriteBool(weapon + offsets.Client("C_EconEntity", "m_AttributeManager") + offsets.Client("C_AttributeContainer", "m_Item") + offsets.Client("C_EconItemView", "m_bInitialized"), true);
                    swed.WriteBool(weapon + offsets.Client("C_EconEntity", "m_AttributeManager") + offsets.Client("C_AttributeContainer", "m_Item") + offsets.Client("C_EconItemView", "m_bDisallowSOC"), false);
                    swed.WriteInt(weapon + offsets.Client("C_EconEntity", "m_AttributeManager") + offsets.Client("C_AttributeContainer", "m_Item") + offsets.Client("C_EconItemView", "m_iItemIDHigh"), -1);
                    swed.WriteInt(weapon + offsets.Client("C_EconEntity", "m_AttributeManager") + offsets.Client("C_AttributeContainer", "m_Item") + offsets.Client("C_EconItemView", "m_iItemIDLow"), -1);
                    swed.WriteBool(weapon + offsets.Client("C_EconEntity", "m_AttributeManager") + offsets.Client("C_AttributeContainer", "m_Item") + offsets.Client("C_EconItemView", "m_bRestoreCustomMaterialAfterPrecache"), true);
                    swed.WriteBool(weapon + offsets.Client("C_EconEntity", "m_AttributeManager") + offsets.Client("C_AttributeContainer", "m_Item") + offsets.Client("C_EconItemView", "m_bIsStoreItem"), false);

                }
                if (weapon_id == 7)
                {
                    swed.WriteBool(weapon + offsets.Client("C_EconEntity", "m_bClientside"), true);
                    swed.WriteInt(weapon + offsets.Client("C_EconEntity", "m_nFallbackPaintKit"), 639);
                    swed.WriteInt(weapon + offsets.Client("C_EconEntity", "m_nFallbackSeed"), seed);
                    swed.WriteInt(weapon + offsets.Client("C_EconEntity", "m_nFallbackStatTrak"), stattrak);
                    swed.WriteInt(weapon + offsets.Client("C_EconEntity", "m_iNumOwnerValidationRetries"), -1);
                    swed.WriteFloat(weapon + offsets.Client("C_EconEntity", "m_flFallbackWear"), wear);
                    swed.WriteString(weapon + offsets.Client("C_EconEntity", "m_AttributeManager") + offsets.Client("C_AttributeContainer", "m_Item") + offsets.Client("C_EconItemView", "m_szCustomName"), m_szCustomName);
                    swed.WriteInt(weapon + offsets.Client("C_EconEntity", "m_AttributeManager") + offsets.Client("C_AttributeContainer", "m_Item") + offsets.Client("C_EconItemView", "m_iEntityQuality"), quality);
                    swed.WriteBool(weapon + offsets.Client("C_EconEntity", "m_AttributeManager") + offsets.Client("C_AttributeContainer", "m_Item") + offsets.Client("C_EconItemView", "m_bInitialized"), true);
                    swed.WriteBool(weapon + offsets.Client("C_EconEntity", "m_AttributeManager") + offsets.Client("C_AttributeContainer", "m_Item") + offsets.Client("C_EconItemView", "m_bDisallowSOC"), false);
                    swed.WriteInt(weapon + offsets.Client("C_EconEntity", "m_AttributeManager") + offsets.Client("C_AttributeContainer", "m_Item") + offsets.Client("C_EconItemView", "m_iItemIDHigh"), -1);
                    swed.WriteInt(weapon + offsets.Client("C_EconEntity", "m_AttributeManager") + offsets.Client("C_AttributeContainer", "m_Item") + offsets.Client("C_EconItemView", "m_iItemIDLow"), -1);
                    swed.WriteBool(weapon + offsets.Client("C_EconEntity", "m_AttributeManager") + offsets.Client("C_AttributeContainer", "m_Item") + offsets.Client("C_EconItemView", "m_bRestoreCustomMaterialAfterPrecache"), true);
                    swed.WriteBool(weapon + offsets.Client("C_EconEntity", "m_AttributeManager") + offsets.Client("C_AttributeContainer", "m_Item") + offsets.Client("C_EconItemView", "m_bIsStoreItem"), false);
                }

                if (weapon_id == 40)
                {
                    swed.WriteBool(weapon + offsets.Client("C_EconEntity", "m_bClientside"), true);
                    swed.WriteInt(weapon + offsets.Client("C_EconEntity", "m_nFallbackPaintKit"), 639);
                    swed.WriteInt(weapon + offsets.Client("C_EconEntity", "m_nFallbackSeed"), seed);
                    swed.WriteInt(weapon + offsets.Client("C_EconEntity", "m_nFallbackStatTrak"), stattrak);
                    swed.WriteInt(weapon + offsets.Client("C_EconEntity", "m_iNumOwnerValidationRetries"), -1);
                    swed.WriteFloat(weapon + offsets.Client("C_EconEntity", "m_flFallbackWear"), wear);
                    swed.WriteString(weapon + offsets.Client("C_EconEntity", "m_AttributeManager") + offsets.Client("C_AttributeContainer", "m_Item") + offsets.Client("C_EconItemView", "m_szCustomName"), m_szCustomName);
                    swed.WriteInt(weapon + offsets.Client("C_EconEntity", "m_AttributeManager") + offsets.Client("C_AttributeContainer", "m_Item") + offsets.Client("C_EconItemView", "m_iEntityQuality"), quality);
                    swed.WriteBool(weapon + offsets.Client("C_EconEntity", "m_AttributeManager") + offsets.Client("C_AttributeContainer", "m_Item") + offsets.Client("C_EconItemView", "m_bInitialized"), true);
                    swed.WriteBool(weapon + offsets.Client("C_EconEntity", "m_AttributeManager") + offsets.Client("C_AttributeContainer", "m_Item") + offsets.Client("C_EconItemView", "m_bDisallowSOC"), false);
                    swed.WriteInt(weapon + offsets.Client("C_EconEntity", "m_AttributeManager") + offsets.Client("C_AttributeContainer", "m_Item") + offsets.Client("C_EconItemView", "m_iItemIDHigh"), -1);
                    swed.WriteInt(weapon + offsets.Client("C_EconEntity", "m_AttributeManager") + offsets.Client("C_AttributeContainer", "m_Item") + offsets.Client("C_EconItemView", "m_iItemIDLow"), -1);
                    swed.WriteBool(weapon + offsets.Client("C_EconEntity", "m_AttributeManager") + offsets.Client("C_AttributeContainer", "m_Item") + offsets.Client("C_EconItemView", "m_bRestoreCustomMaterialAfterPrecache"), true);
                    swed.WriteBool(weapon + offsets.Client("C_EconEntity", "m_AttributeManager") + offsets.Client("C_AttributeContainer", "m_Item") + offsets.Client("C_EconItemView", "m_bIsStoreItem"), false);
                }
            }
            catch (Exception e)
            {
                Log.Error($"SkinChanger::set_weapon_skin feature encountered an error: {e.Message}");
            }

        }


            
        public static void perform_full_update()
        {
            var game_client = swed.ReadPointer(engine + offsets.Engine2dll("dwNetworkGameClient"));
            swed.WriteInt(game_client + offsets.Engine2dll("dwNetworkGameClient_deltaTick"), -1);
        }

        public static IntPtr get_controller_from_handle(IntPtr entityList, int handle)
        {
            IntPtr list_entry = swed.ReadPointer(entityList + 0x8 * ((handle & 0x7FFF) >> 9) + 16);
            if (list_entry == IntPtr.Zero) return IntPtr.Zero;
            return swed.ReadPointer(list_entry + 120 * (handle & 0x1FF));
        }
        public static void Run()
        {
            Log.Info("SkinChanger feature started.");
            while (true)
            {
                try
                {   
                    IntPtr local_player = swed.ReadPointer(clientcs + offsets.Offset("dwLocalPlayerPawn"));

                    bool m_bIsBuyMenuOpen = swed.ReadBool(local_player + offsets.Client("C_CSPlayerPawn", "m_bIsBuyMenuOpen"));
                    if (!m_bIsBuyMenuOpen) continue;

                    IntPtr entity_list = swed.ReadPointer(clientcs, offsets.Offset("dwEntityList"));

                    IntPtr weapon_service = swed.ReadPointer(local_player + offsets.Client("C_BasePlayerPawn", "m_pWeaponServices"));
                    int weapons_count = swed.ReadInt(weapon_service + offsets.Client("CPlayer_WeaponServices", "m_hMyWeapons"));
                    IntPtr weapons = swed.ReadPointer(weapon_service + offsets.Client("CPlayer_WeaponServices", "m_hMyWeapons") + 0x8);
                    
                    for (int i = 0; i < weapons_count; i++)
                    {
                        var weapon_handle = swed.ReadInt(weapons + i * 0x4);
                        if (weapon_handle == 0) continue;

                        var weapon_controller = get_controller_from_handle(entity_list, weapon_handle);
                        if (weapon_controller == IntPtr.Zero) continue;

                        short weapon_id = swed.ReadShort(
                            weapon_controller,
                            offsets.Client("C_EconEntity", "m_AttributeManager") +
                            offsets.Client("C_AttributeContainer", "m_Item") +
                            offsets.Client("C_EconItemView", "m_iItemDefinitionIndex")
                        );
                        if (weapon_id == 0) continue;


                        var weapon_node = swed.ReadPointer(weapon_controller + offsets.Client("C_BaseEntity", "m_pGameSceneNode"));
                        var weapon_mask = swed.ReadInt(weapon_node + offsets.Client("CSkeletonInstance", "m_modelState") + offsets.Client("CModelState", "m_MeshGroupMask"));
                        int account_id = swed.ReadInt(clientcs + offsets.Client("C_EconEntity", "m_OriginalOwnerXuidLow"));

                        
                        var m_nFallbackSeed = 0;
                        var m_nFallbackStatTrak = 696969;
                        var m_flFallbackWear = 0.00001f;
                        var m_szCustomName = "keyblade";
                        var m_iItemIDHigh = -1;
                        var m_nFallbackPaintKit = 279;
                        var m_bDisallowSOC = false;
                        var m_iEntityQuality = 3;


                        var view_handle = swed.ReadInt(local_player + offsets.Client("C_CSPlayerPawnBase", "m_pViewModelServices") + offsets.Client("CCSPlayer_ViewModelServices", "m_hViewModel"));
                        var view_controller = get_controller_from_handle(entity_list, view_handle);

                        var view_node = swed.ReadPointer(view_controller + offsets.Client("C_BaseEntity", "m_pGameSceneNode"));

                        IntPtr weapon_game_scene_node = swed.ReadPointer(weapon_controller + offsets.Client("C_BaseEntity", "m_pGameSceneNode"));
                        
                        swed.WriteInt(view_node + offsets.Client("CSkeletonInstance", "m_modelState") + offsets.Client("CModelState", "m_MeshGroupMask"), 2);
                        swed.WriteInt(weapon_game_scene_node + offsets.Client("CSkeletonInstance", "m_modelState") + offsets.Client("CModelState", "m_MeshGroupMask"), 2);

                        set_weapon_skin(weapon_id, account_id, weapon_controller, m_nFallbackPaintKit, m_nFallbackSeed, m_flFallbackWear, m_szCustomName, m_nFallbackStatTrak, m_iEntityQuality, m_bDisallowSOC, m_iItemIDHigh);

                        perform_full_update();


                    }

                }
                catch (Exception e)
                {
                    Log.Error($"SkinChanger feature encountered an error: {e.Message}");
                }
            }
        }

    }
}

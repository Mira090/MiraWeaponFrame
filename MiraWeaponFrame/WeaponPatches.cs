using HarmonyLib;
using MiraWeaponFrame.Compat;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace MiraWeaponFrame
{
    public static class WeaponPatches
    {
        [HarmonyPatch(typeof(BossSpawner), "ApplyClearProgressionLocal")]
        public static class BossPatch
        {
            static void Postfix(BossSpawner __instance, string bossName, string achievementID, string clearSwitchName, int gameClearType, int randomID)
            {
                if (gameClearType <= 0)
                    return;

                PlayerAvatar playerAvatar = (CombatManager.Instance ? CombatManager.Instance.CurrentPlayer : null);
                if (playerAvatar == null || !playerAvatar.gameObject.TryGetComponent<WeaponControllerSimple>(out var weapon) || !weapon.currentWeapon)
                {
                    return;
                }


                var current = DungeonManager.Instance.CalculateCurrentHardModePoints();
                var currentBossRush = DungeonManager.Instance.hardModeShardLevels.ContainsKey(RaidRaidCompat.BossRush) ? DungeonManager.Instance.hardModeShardLevels[RaidRaidCompat.BossRush] : 0;

                var saved = SaveManager.Current.GetInt("HardModeClearedHighestPoint_Weapon_" + weapon.currentWeapon.entityId, 0);
                if (currentBossRush == 0 && current > saved)
                {
                    SaveManager.Current.SetInt("HardModeClearedHighestPoint_Weapon_" + weapon.currentWeapon.entityId, current);
                }
                var bossrush = SaveManager.Current.GetInt($"HardModeClearedHighestPoint_Weapon_{weapon.currentWeapon.entityId}_RaidRaid_BossRush", 0);
                if (currentBossRush > 0 && current > bossrush)
                {
                    SaveManager.Current.SetInt($"HardModeClearedHighestPoint_Weapon_{weapon.currentWeapon.entityId}_RaidRaid_BossRush", current);
                }

                var bossrush2 = SaveManager.Current.GetInt($"HardModeClearedHighestPoint_Costume_{playerAvatar.currentCostume}_RaidRaid_BossRush", 0);
                if (currentBossRush > 0 && current > bossrush2)
                {
                    SaveManager.Current.SetInt($"HardModeClearedHighestPoint_Costume_{playerAvatar.currentCostume}_RaidRaid_BossRush", current);
                }

                /*
                if (RaidRaidCompat.TryGetSapphireBonus(out var bonus))
                {
                    var savedBonus = SaveManager.Current.GetInt($"HardModeClearedHighestPoint_Weapon_{weapon.currentWeapon.entityId}_RaidRaid_SapphireBonus", 0);
                    if (bonus > savedBonus)
                    {
                        SaveManager.Current.SetInt($"HardModeClearedHighestPoint_Weapon_{weapon.currentWeapon.entityId}_RaidRaid_SapphireBonus", bonus);
                    }
                    var savedBonus2 = SaveManager.Current.GetInt($"HardModeClearedHighestPoint_Costume_{weapon.currentWeapon.entityId}_RaidRaid_SapphireBonus", 0);
                    if (bonus > savedBonus2)
                    {
                        SaveManager.Current.SetInt($"HardModeClearedHighestPoint_Costume_{weapon.currentWeapon.entityId}_RaidRaid_SapphireBonus", bonus);
                    }
                }*/
            }
        }
        [HarmonyPatch(typeof(UI_WeaponIcon), nameof(UI_WeaponIcon.SetWeapon), new Type[] { typeof(WeaponEntity) })]
        public static class WeaponIconPatch
        {
            static void Postfix(UI_WeaponIcon __instance, WeaponEntity weapon)
            {
                if (weapon == null)
                    return;
                if(__instance.TryGetComponent<UI_WeaponIconMod>(out var mod))
                {
                    mod.SetWeapon(weapon);
                }
                else
                {
                    var newMod = __instance.gameObject.AddComponent<UI_WeaponIconMod>();
                    newMod.Initialize();
                    newMod.SetWeapon(weapon);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MiraWeaponFrame.Compat
{
    public static class RaidRaidCompat
    {
        public static readonly string BossRush = "RAIDRAID_BOSSRUSH";

        [Obsolete]
        public static bool TryGetSapphireBonus(out int percent)
        {
            foreach (var mod in AddOnLoader.LoadedMods)
            {
                try
                {
                    var types = mod.Assembly.GetTypes();
                    foreach(var type in types)
                    {
                        Core.Logger("Class: " + type.FullName);
                        if (type.FullName == "RaidRaid.ScalerWindow")
                        {
                            Core.Logger("mod: " + mod.Metadata.modName);
                            if (!type.TryGetStaticField("_instance", out object instance))
                            {
                                Core.LoggerError("_instance not found");
                                continue;
                            }
                            if (instance.TryGetField("_sumBonusInt", out int bonus))
                            {
                                percent = bonus;
                                return percent >= 0;
                            }
                            else
                            {
                                Core.LoggerError("_sumBonusInt not found");
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Core.LoggerWarning(e);
                }
            }
            percent = 0;
            return false;
        }
    }
}

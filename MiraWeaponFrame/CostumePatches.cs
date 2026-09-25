using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiraWeaponFrame
{
    public static class CostumePatches
    {
        [HarmonyPatch(typeof(UI_CostumeListElement), nameof(UI_CostumeListElement.Initialize))]
        public static class CostumeUIPatch
        {
            static void Postfix(UI_CostumeListElement __instance, CostumeEntity costume)
            {
                int int2 = SaveManager.Current.GetInt("HardModeClearedHighestPoint_Costume_" + costume.id, 0);
            }
        }
    }
}

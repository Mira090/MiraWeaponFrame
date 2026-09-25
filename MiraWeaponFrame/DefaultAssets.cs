using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MiraWeaponFrame
{
    public static class DefaultAssets
    {
        public static Sprite Weapon15 { get; private set; }
        public static Sprite Weapon30 { get; private set; }
        public static Sprite Weapon40 { get; private set; }
        public static Sprite Weapon50 { get; private set; }
        public static Sprite Weapon60 { get; private set; }

        public static Sprite HardModeIcon { get; private set; }
        public static Sprite HardModeBossRushIcon { get; private set; }
        public static Sprite HardModeSapphireBonusIcon { get; private set; }

        public static void Initialize()
        {
            Weapon15 = AssetLoader.LoadSprite(AssetLoader.UIPath + "Weapon15");
            Weapon30 = AssetLoader.LoadSprite(AssetLoader.UIPath + "Weapon30");
            Weapon40 = AssetLoader.LoadSprite(AssetLoader.UIPath + "Weapon40");
            Weapon50 = AssetLoader.LoadSprite(AssetLoader.UIPath + "Weapon50");
            Weapon60 = AssetLoader.LoadSprite(AssetLoader.UIPath + "Weapon60");
            HardModeIcon = AssetLoader.LoadSprite(AssetLoader.UIPath + "HardModeIcon");
            HardModeBossRushIcon = AssetLoader.LoadSprite(AssetLoader.UIPath + "HardModeIcon_RaidRaid_BossRush");
            HardModeSapphireBonusIcon = AssetLoader.LoadSprite(AssetLoader.UIPath + "HardModeIcon_RaidRaid_SapphireBonus");
        }
        public static void Destroy()
        {
            UnityEngine.Object.Destroy(Weapon15);
            UnityEngine.Object.Destroy(Weapon30);
            UnityEngine.Object.Destroy(Weapon40);
            UnityEngine.Object.Destroy(Weapon50);
            UnityEngine.Object.Destroy(Weapon60);
            UnityEngine.Object.Destroy(HardModeIcon);
            UnityEngine.Object.Destroy(HardModeBossRushIcon);
            UnityEngine.Object.Destroy(HardModeSapphireBonusIcon);
        }
    }
}

using HarmonyLib;
using MiraWeaponFrame.Config;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MiraWeaponFrame
{
    public class Core : HorayModBase
    {
        public static readonly string ModName = "Mira's Weapon Frame";
        public static void Logger(string message)
        {
            Debug.Log($"[{ModName}] " + message);
        }
        public static void LoggerWarning(string message)
        {
            Debug.LogWarning($"[{ModName}] " + message);
        }
        public static void LoggerWarning(System.Exception message)
        {
            Debug.LogWarning($"[{ModName}] " + message);
        }
        public static void LoggerError(string message)
        {
            Debug.LogError($"[{ModName}] " + message);
        }
        public static void LoggerError(System.Exception message)
        {
            Debug.LogError($"[{ModName}] " + message);
        }
        public static Core Instance { get; private set; }
        public static Harmony ModPatches { get; private set; }
        public static bool IsInitialized { get; private set; } = false;
        protected override void OnModLoaded()
        {
            base.OnModLoaded();

            if (!IsInitialized)
            {
                IsInitialized = true;
                Instance = this;

                ModPatches = new Harmony("com.Mira." + ModName);
                ModPatches.PatchAll();

                HorayModAPI.OnLocalizationReady += OnLocalizationReady;

                ConfigManager.Init();
                DefaultAssets.Initialize();
            }
        }
        protected override void OnModUnloaded()
        {
            IsInitialized = false;

            HorayModAPI.OnLocalizationReady -= OnLocalizationReady;

            DefaultAssets.Destroy();

            if (ModPatches != null)
            {
                ModPatches.UnpatchSelf();
            }

            base.OnModUnloaded();
        }


        private static void OnLocalizationReady(HorayModLocalizationContext context)
        {
            var enUS = "en-US";
            var jaJP = "ja-JP";
            var koKR = "ko-KR";
            context.AddText(enUS, "UI_MiraWeaponFrame_HasFrame", "Add the frame of completed Hard Mode Difficulty to the weapon icon.");
            context.AddText(enUS, "UI_MiraWeaponFrame_HasText", "Add the number of completed Hard Mode Difficulty to the weapon icon.");
            context.AddText(enUS, "UI_MiraWeaponFrame_HasFrame_True", "On");
            context.AddText(enUS, "UI_MiraWeaponFrame_HasFrame_False", "Off");
            context.AddText(enUS, "UI_MiraWeaponFrame_HasText_True", "On");
            context.AddText(enUS, "UI_MiraWeaponFrame_HasText_False", "Off");

            context.AddText(jaJP, "UI_MiraWeaponFrame_HasFrame", "武器アイコンにクリアしたハードモードのフレームを追加");
            context.AddText(jaJP, "UI_MiraWeaponFrame_HasText", "武器アイコンにクリアしたハードモードの数字を追加");
            context.AddText(jaJP, "UI_MiraWeaponFrame_HasFrame_True", "あり");
            context.AddText(jaJP, "UI_MiraWeaponFrame_HasFrame_False", "なし");
            context.AddText(jaJP, "UI_MiraWeaponFrame_HasText_True", "あり");
            context.AddText(jaJP, "UI_MiraWeaponFrame_HasText_False", "なし");

            context.AddText(koKR, "UI_MiraWeaponFrame_HasFrame", "무기 아이콘에 클리어한 하드 모드의 프레임을 추가");
            context.AddText(koKR, "UI_MiraWeaponFrame_HasText", "무기 아이콘에 클리어한 하드 모드의 숫자를 추가");
            context.AddText(koKR, "UI_MiraWeaponFrame_HasFrame_True", "있음");
            context.AddText(koKR, "UI_MiraWeaponFrame_HasFrame_False", "없음");
            context.AddText(koKR, "UI_MiraWeaponFrame_HasText_True", "있음");
            context.AddText(koKR, "UI_MiraWeaponFrame_HasText_False", "없음");
        }


        public List<List<string>> ModOptions => new List<List<string>>{
            new List<string>{ "UI_MiraWeaponFrame_HasFrame_True", "UI_MiraWeaponFrame_HasFrame_False" },
            new List<string>{ "UI_MiraWeaponFrame_HasText_True", "UI_MiraWeaponFrame_HasText_False" }};
        public List<string> ModOptionsDescription => new List<string> { "UI_MiraWeaponFrame_HasFrame", "UI_MiraWeaponFrame_HasText" };
        public List<int> ModOptionsCurrent => new List<int> { ConfigManager.Config.HasFrame ? 0 : 1, ConfigManager.Config.HasText ? 0 : 1 };
        public bool UseLocalizedSring => true;
        public void OnModOptionChanged(int index, int value)
        {
            if (index == 0)
            {
                ConfigManager.Config.HasFrame = value == 0;
                ConfigManager.SaveConfig();
                Core.Logger("Changed: " + ModOptions[index][value]);
            }
            else if (index == 1)
            {
                ConfigManager.Config.HasText = value == 0;
                ConfigManager.SaveConfig();
                Core.Logger("Changed: " + ModOptions[index][value]);
            }
        }
    }
}

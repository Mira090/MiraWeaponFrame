using MiraWeaponFrame.Config;
using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MiraWeaponFrame
{
    public class UI_WeaponIconMod : MonoBehaviour
    {
        public Image frameImage;
        public Image hardModeIconImage;
        public TextMeshProUGUI hardModeValueText;
        public Image bossRushIconImage;
        public TextMeshProUGUI bossRushValueText;
        public Image sapphireBonusIconImage;
        public TextMeshProUGUI sapphireBonusValueText;
        public void Initialize()
        {
            var rectTransform = transform as RectTransform;

            var frameObject = new GameObject("Frame");
            frameObject.transform.SetParent(transform);
            frameObject.transform.SetSiblingIndex(1);
            frameImage = frameObject.AddComponent<Image>();
            frameImage.raycastTarget = false;
            frameImage.rectTransform.anchoredPosition = Vector2.zero;
            frameImage.rectTransform.localScale = Vector3.one;
            frameImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, rectTransform.rect.size.x);
            frameImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rectTransform.rect.size.y);

            var hardSize = 25;

            var iconObject = new GameObject("HardModeIcon");
            iconObject.transform.SetParent(transform);
            iconObject.transform.SetAsLastSibling();
            hardModeIconImage = iconObject.AddComponent<Image>();
            hardModeIconImage.raycastTarget = false;
            hardModeIconImage.rectTransform.pivot = new Vector2(0, 1);
            hardModeIconImage.rectTransform.anchorMin = new Vector2(0, 1);
            hardModeIconImage.rectTransform.anchorMax = new Vector2(0, 1);
            hardModeIconImage.rectTransform.anchoredPosition = new Vector2(0, -2);
            hardModeIconImage.rectTransform.localScale = Vector3.one * 0.5f;
            hardModeIconImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, hardSize);
            hardModeIconImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, hardSize);
            hardModeIconImage.sprite = DefaultAssets.HardModeIcon;

            var textObject = new GameObject("HardModeText");
            textObject.transform.SetParent(hardModeIconImage.transform);
            hardModeValueText = textObject.AddComponent<TextMeshProUGUI>();
            hardModeValueText.raycastTarget = false;
            hardModeValueText.rectTransform.anchoredPosition = Vector2.zero;
            hardModeValueText.rectTransform.localScale = Vector3.one * 2f;
            hardModeValueText.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, hardSize);
            hardModeValueText.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, hardSize);

            //hardModeValueText.margin = new Vector4(3, 3, 4, 4);
            hardModeValueText.fontSize = 8;
            hardModeValueText.alignment = TextAlignmentOptions.Center;
            hardModeValueText.textWrappingMode = TextWrappingModes.NoWrap;

            var original = UIManager.Instance.GetElement<UI_CostumePanel>().hardModeValueText;
            hardModeValueText.font = original.font;
            hardModeValueText.fontMaterial = original.fontMaterial;

            var iconBoss = new GameObject("BossRushIcon");
            iconBoss.transform.SetParent(transform);
            iconBoss.transform.SetAsLastSibling();
            bossRushIconImage = iconBoss.AddComponent<Image>();
            bossRushIconImage.raycastTarget = false;
            bossRushIconImage.rectTransform.pivot = new Vector2(0, 0.5f);
            bossRushIconImage.rectTransform.anchorMin = new Vector2(0, 0.5f);
            bossRushIconImage.rectTransform.anchorMax = new Vector2(0, 0.5f);
            bossRushIconImage.rectTransform.anchoredPosition = new Vector2(0, 0);
            bossRushIconImage.rectTransform.localScale = Vector3.one * 0.5f;
            bossRushIconImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, hardSize);
            bossRushIconImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, hardSize);
            bossRushIconImage.sprite = DefaultAssets.HardModeBossRushIcon;

            var textBoss = new GameObject("BossRushText");
            textBoss.transform.SetParent(bossRushIconImage.transform);
            bossRushValueText = textBoss.AddComponent<TextMeshProUGUI>();
            bossRushValueText.raycastTarget = false;
            bossRushValueText.rectTransform.anchoredPosition = Vector2.zero;
            bossRushValueText.rectTransform.localScale = Vector3.one * 2f;
            bossRushValueText.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, hardSize);
            bossRushValueText.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, hardSize);

            //bossRushValueText.margin = new Vector4(3, 3, 4, 4);
            bossRushValueText.fontSize = 8;
            bossRushValueText.alignment = TextAlignmentOptions.Center;
            bossRushValueText.textWrappingMode = TextWrappingModes.NoWrap;

            bossRushValueText.font = original.font;
            bossRushValueText.fontMaterial = original.fontMaterial;

            var iconSapphire = new GameObject("SapphireBonusIcon");
            iconSapphire.transform.SetParent(transform);
            iconSapphire.transform.SetAsLastSibling();
            sapphireBonusIconImage = iconSapphire.AddComponent<Image>();
            sapphireBonusIconImage.raycastTarget = false;
            sapphireBonusIconImage.rectTransform.pivot = new Vector2(0, 0);
            sapphireBonusIconImage.rectTransform.anchorMin = new Vector2(0, 0);
            sapphireBonusIconImage.rectTransform.anchorMax = new Vector2(0, 0);
            sapphireBonusIconImage.rectTransform.anchoredPosition = new Vector2(0, 2);
            sapphireBonusIconImage.rectTransform.localScale = Vector3.one * 0.5f;
            sapphireBonusIconImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, hardSize);
            sapphireBonusIconImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, hardSize);
            sapphireBonusIconImage.sprite = DefaultAssets.HardModeSapphireBonusIcon;

            var textSapphire = new GameObject("SapphireBonusText");
            textSapphire.transform.SetParent(sapphireBonusIconImage.transform);
            sapphireBonusValueText = textSapphire.AddComponent<TextMeshProUGUI>();
            sapphireBonusValueText.raycastTarget = false;
            sapphireBonusValueText.rectTransform.anchoredPosition = Vector2.zero;
            sapphireBonusValueText.rectTransform.localScale = Vector3.one * 2f;
            sapphireBonusValueText.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, hardSize);
            sapphireBonusValueText.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, hardSize);

            //sapphireBonusValueText.margin = new Vector4(3, 3, 4, 4);
            sapphireBonusValueText.fontSize = 6;
            sapphireBonusValueText.alignment = TextAlignmentOptions.Center;
            sapphireBonusValueText.textWrappingMode = TextWrappingModes.NoWrap;

            sapphireBonusValueText.font = original.font;
            sapphireBonusValueText.fontMaterial = original.fontMaterial;
        }
        public void SetWeapon(WeaponEntity weapon)
        {
            var saved = SaveManager.Current.GetInt("HardModeClearedHighestPoint_Weapon_" + weapon.id, 0);
            //if (ScreenFader.Instance != null && ScreenFader.Instance.IsTestMode)//テスト用
                //saved = UnityEngine.Random.Range(-99, 99);

            //hardModeValueText.gameObject.SetActive(saved > 0 && ConfigManager.Config.HasText);
            hardModeIconImage.gameObject.SetActive(saved > 0 && ConfigManager.Config.HasText);
            hardModeValueText.text = saved.ToString();

            var bossrush = SaveManager.Current.GetInt($"HardModeClearedHighestPoint_Weapon_{weapon.id}_RaidRaid_BossRush", 0);
            bossRushIconImage.gameObject.SetActive(bossrush > 0 && ConfigManager.Config.HasText);
            bossRushValueText.text = bossrush.ToString();

            var savedBonus = SaveManager.Current.GetInt($"HardModeClearedHighestPoint_Weapon_{weapon.id}_RaidRaid_SapphireBonus", 0);
            sapphireBonusIconImage.gameObject.SetActive(savedBonus > 0 && ConfigManager.Config.HasText);
            sapphireBonusValueText.text = savedBonus.ToString() + "%";

            var max = Mathf.Max(saved, bossrush);
            frameImage.gameObject.SetActive(max >= 15 && ConfigManager.Config.HasFrame);
            if (max >= 60)
            {
                frameImage.sprite = DefaultAssets.Weapon60 ?? frameImage.sprite;
            }
            else if(max >= 50)
            {
                frameImage.sprite = DefaultAssets.Weapon50 ?? frameImage.sprite;
            }
            else if (max >= 40)
            {
                frameImage.sprite = DefaultAssets.Weapon40 ?? frameImage.sprite;
            }
            else if (max >= 30)
            {
                frameImage.sprite = DefaultAssets.Weapon30 ?? frameImage.sprite;
            }
            else if (max >= 15)
            {
                frameImage.sprite = DefaultAssets.Weapon15 ?? frameImage.sprite;
            }
        }
    }
}

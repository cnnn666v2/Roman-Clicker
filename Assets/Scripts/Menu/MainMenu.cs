using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    [Header("Upgrades")]
    public GameObject RomanStore;
    public GameObject ClickShop;
    public GameObject ItemShop;
    public GameObject PowerShop;
    public GameObject EggShop;

    [Header("Pop-ups")]
    public GameObject UpgradePanel;
    public GameObject SettingsPanel;
    public GameObject BattlePanel;

    [Header("Other")]
    public GameObject FPSText;

    /////////
    // Upgrade Categories
    /////////
        public void TogglePanel() {
            if(UpgradePanel.activeInHierarchy == false)
                UpgradePanel.SetActive(true);
            else
                UpgradePanel.SetActive(false);
        }

        public void ToggleSettings() {
            if(SettingsPanel.activeInHierarchy == false)
                SettingsPanel.SetActive(true);
            else
                SettingsPanel.SetActive(false);
        }

        public void ToggleFPSText() {
            if(FPSText.activeInHierarchy == false)
                FPSText.SetActive(true);
            else
                FPSText.SetActive(false);
        }

        public void ToggleBattlePanel() {
            if(BattlePanel.activeInHierarchy == false)
                BattlePanel.SetActive(true);
            else
                BattlePanel.SetActive(false);
        }

    /////////
    // Upgrade Categories
    /////////
        public void UpgradeRomans() {
            RomanStore.SetActive(true);
            ClickShop.SetActive(false);
            ItemShop.SetActive(false);
            PowerShop.SetActive(false);
            EggShop.SetActive(false);
        }

        public void UpgradeClicks() {
            RomanStore.SetActive(false);
            ClickShop.SetActive(true);
            ItemShop.SetActive(false);
            PowerShop.SetActive(false);
            EggShop.SetActive(false);
        }

        public void UpgradeItems() {
            RomanStore.SetActive(false);
            ClickShop.SetActive(false);
            ItemShop.SetActive(true);
            PowerShop.SetActive(false);
            EggShop.SetActive(false);
        }

        public void UpgradePower() {
            RomanStore.SetActive(false);
            ClickShop.SetActive(false);
            ItemShop.SetActive(false);
            PowerShop.SetActive(true);
            EggShop.SetActive(false);
        }

        public void UpgradeEgg() {
            RomanStore.SetActive(false);
            ClickShop.SetActive(false);
            ItemShop.SetActive(false);
            PowerShop.SetActive(false);
            EggShop.SetActive(true);
        }
}

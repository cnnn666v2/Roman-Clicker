using UnityEngine;
using TMPro;

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

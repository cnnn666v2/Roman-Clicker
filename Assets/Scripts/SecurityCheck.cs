using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SecurityCheck : MonoBehaviour
{
    // Reference scripts
    [SerializeField] PlayerStats PS;
    [SerializeField] SaveLoad SL;
    [SerializeField] ChangePlayer CP;

    // Anticheat panel
    [SerializeField] GameObject PopUPPanel, PopUPBtnGroup;
    [SerializeField] TMP_Text PopupTitle, PopupDescription;
    [SerializeField] Button PopupButton;

    void Start()
    {
        ErrorCheck();
        // Check for illegality
        //RunCheck();
    }

    void ErrorCheck()
    {
        if(PS.PlayerMaxHealth <= 5) {
            PopUPPanel.SetActive(true);
            PopupTitle.text = "Warning - Potential corrupted save file";
            PopupDescription.text = "Detected a possibility of a corrupted save file. You may ignore the issue, but it might result in more errors, crashes, etc.<br>You can reset your player statistics (owned items or spells won't be affected) to fix the problem.";
            PopUPBtnGroup.SetActive(true);
        }
    }

    public void RunCheck()
    {
        CheckInv();
        CheckItems();
    }

    void CheckInv()
    {
        Debug.Log("[CP]: Entering CInv()");
        if (!SaveLoad.inventory.OwnedItems.Any(item => item.ItemID == 0))
        {
            Image BackgroundImg = PopUPPanel.GetComponent<Image>();
            BackgroundImg.color = new Color(1f, 1f, 0f, 0.8f);
            PopUPPanel.gameObject.SetActive(true);
            PopupTitle.text = "WARNING";
            PopupDescription.text = "Looks like you've tempered with your save file. Fine, if you think you're <i>that</i> good, then come visist the game's github repository and help me work on the game!";
            PopupButton.onClick.AddListener(AddNull);
            Debug.Log("Added a listener");
        }
        Debug.Log("[CP]: Leaving CInv()");
    }

    void CheckItems()
    {
        Debug.Log("[CP]: Entering CI()");
        if (!SaveLoad.inventory.OwnedItems.Any(item => item.ItemID == SaveLoad.playercharacter.slot1) ||
            !SaveLoad.inventory.OwnedItems.Any(item => item.ItemID == SaveLoad.playercharacter.slot2) ||
            !SaveLoad.inventory.OwnedItems.Any(item => item.ItemID == SaveLoad.playercharacter.slot3))
        {
            Image BackgroundImg = PopUPPanel.GetComponent<Image>();
            BackgroundImg.color = new Color(1f, 0f, 0f, 0.8f);
            PopUPPanel.gameObject.SetActive(true);
            PopupTitle.text = "WARNING";
            PopupDescription.text = "You have illegal items equipped.\nAny selected items will be deselcted automatically. Please equip your items again.";
            PopupButton.onClick.AddListener(ResetItems);
            Debug.Log("Added a listener");
        }
        Debug.Log("[CP]: Leaving CI()");
    }

    void AddNull()
    {
        Debug.Log("[CP]: Entering AL()");
        SL.AddNewItem(0, 0);

        PopUPPanel.SetActive(false);
        PS.LoadPlayer();
        CP.LoadCharacterInfo();

        SL.SaveToJson();
        PopupButton.onClick.RemoveAllListeners();

        Debug.Log("[CP]: Leaving AL()");
    }

    void ResetItems()
    {
        Debug.Log("[CP]: Entering RI()");
        SaveLoad.playercharacter.slot1 = 0;
        SaveLoad.playercharacter.slot2 = 0;
        SaveLoad.playercharacter.slot3 = 0;

        PopUPPanel.SetActive(false);
        PS.LoadPlayer();
        CP.LoadCharacterInfo();

        SL.SaveToJson();
        PopupButton.onClick.RemoveAllListeners();

        Debug.Log("[CP]: Leaving RI()");
    }

    public void HidePanel()
    {
        PopUPPanel.SetActive(false);
        PopUPBtnGroup.SetActive(false);
    }

    public void ReloadScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

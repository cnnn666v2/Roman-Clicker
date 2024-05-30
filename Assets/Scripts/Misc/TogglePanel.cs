using UnityEngine;

public class TogglePanel : MonoBehaviour
{
    public void ToggleUIPanel(GameObject panel)
    {
        // Check if panel (popup/overlay) is active
        if (panel.activeInHierarchy == true) {
            panel.SetActive(false);
            Debug.Log("Panel: " + panel.name + " has been hidden");
        } else {
            panel.SetActive(true);
            Debug.Log("Panel: " + panel.name + " has been displayed");
        }
    }

    public void SetItemInfo()
    {
        GameObject panel = GameObject.FindGameObjectWithTag("ItemInfoPanel");
        panel.SetActive(true);
    }
}

using UnityEngine;

public class SwitchInvPanels : MonoBehaviour
{
    // Reference parent of inventory categories panels
    [SerializeField]
    Transform PanelsParent;

    // Reference skill info panel just to disable it, it's a very special use case
    [SerializeField]
    GameObject SkillInfoPanel;

    public void SwitchPanel(GameObject panel)
    {
        // Disable every child
        foreach (Transform child in PanelsParent) {
            child.gameObject.SetActive(false);
            Debug.Log("Panel: " + child.name + " has been hidden");
        }

        // Enable desired panel
        panel.SetActive(true);
        Debug.Log("Panel: " + panel.name + " has been displayed");
    }

    public void DisableSIP()
    {
        // Disable skill info panel, SIP (above/method name) stands for SkillInfoPanel
        SkillInfoPanel.SetActive(false);
    }
}

using UnityEngine;

public class SwitchInvPanels : MonoBehaviour
{
    // Reference parent of inventory categories panels
    [SerializeField]
    Transform PanelsParent;

    public void SwitchPanel(GameObject panel)
    {
        // Disable every child
        foreach (Transform child in PanelsParent)
        {
            child.gameObject.SetActive(false);
            Debug.Log("Panel: " + child.name + " has been hidden");
        }

        // Enable desired panel
        panel.SetActive(true);
        Debug.Log("Panel: " + panel.name + " has been displayed");
    }
}

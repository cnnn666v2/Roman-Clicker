using TMPro;
using UnityEngine;

public class BuildInfoGUI : MonoBehaviour
{
    [SerializeField] TMP_Text BuildInfoTXT;

    void Start()
    {
        BuildInfoTXT.text = "Current build: <color=orange>" + PlayerPrefs.GetString("version-branch") + " <color=green>" + PlayerPrefs.GetFloat("version-number") + "<color=white> | 2024";
    }
}

using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleMenu : MonoBehaviour
{
    [Header("Texts")]
    public TMP_Text SelectedAreaTXT;
    public TMP_Text SAHighestScoreTXT;
    public TMP_Text SADifficultyTXT;
    public TMP_Text TempTXT;

    [Header("Areas")]
    public List<string> AreaList;
    public List<string> AreaDifficultyList;
    public List<int> AreaHSList;
    public List<int> AreaSceneIndexList;

    [Header("Other")]
    private int currentIndex = 0;

    void Start() {
        SelectedAreaTXT.text = "Current Area: " + AreaList[currentIndex];
        SAHighestScoreTXT.text = "Highest Level: " + AreaHSList[currentIndex].ToString();
        SADifficultyTXT.text = "Difficulty: " + AreaDifficultyList[currentIndex];
    }

    public void ChangeArea() {
        currentIndex = (currentIndex + 1) % AreaList.Count;
        SelectedAreaTXT.text = "Current Area: " + AreaList[currentIndex];
        SAHighestScoreTXT.text = "Highest Level: " + AreaHSList[currentIndex].ToString();
        SADifficultyTXT.text = "Difficulty: " + AreaDifficultyList[currentIndex];
        TempTXT.text = "Area Load Scene: " + AreaSceneIndexList[currentIndex];
    }
}

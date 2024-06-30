using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class ToggleArenas : MonoBehaviour
{
    [Header("Text Fields")]
    public TMP_Text ArenaNameTXT;
    public TMP_Text AreaDifficultyTXT;
    public TMP_Text AreaHSTXT;
    public TMP_Text ArenaDescriptionTXT;
    public TMP_Text ArenaCountTXT;

    [Header("Arenas")]
    public List<string> ArenaName;
    public List<string> ArenaDifficulty;
    public List<string> ArenaDescription;
    public List<int> ArenaHighscore;
    public List<int> ArenaSceneIndex;

    [Header("Misc")]
    public int currentIndex;

    void Start()
    {
        // Default the index to 0
        currentIndex = 0;

        // Set Arena name to current index (0)
        ArenaNameTXT.text = "Arena - " + ArenaName[currentIndex];
        ArenaCountTXT.text = "Arena: " + (currentIndex + 1) + "/" + ArenaName.Count;
        Debug.Log("Loaded: " + "Arena name:" + ArenaName[currentIndex] + ", Index: " + currentIndex + ", Count: " + ArenaName.Count + " || Current scene index: " + ArenaSceneIndex[currentIndex]);
    }

    public void SwitchArena()
    {
        // Cycle the index through the list
        currentIndex = (currentIndex + 1) % ArenaName.Count;
        // Set text to match current arena index
        ArenaNameTXT.text = "Arena - " + ArenaName[currentIndex];
        ArenaCountTXT.text = "Arena: " + (currentIndex + 1) + "/" + ArenaName.Count;
        Debug.Log("Current arena index name: " + ArenaName[currentIndex] + " || Current index: " + currentIndex + " || Current scene index: " + ArenaSceneIndex[currentIndex]);
    }

    public void SwitchArenaPrev()
    {
        // Cycle the index through the list backwards
        currentIndex = (currentIndex - 1 + ArenaName.Count) % ArenaName.Count;
        // Set text to match current arena index
        ArenaNameTXT.text = "Arena - " + ArenaName[currentIndex];
        ArenaCountTXT.text = "Arena: " + ((currentIndex - 1) + ArenaName.Count - 1) + "/" + ArenaName.Count;
        Debug.Log("Current arena index name: " + ArenaName[currentIndex] + " || Current index: " + currentIndex + " || Current scene index: " + ArenaSceneIndex[currentIndex]);
    }

    public void StartGame()
    {
        // Load Arena based on its scene index
        SceneManager.LoadScene(ArenaSceneIndex[currentIndex]);
        Debug.Log("Loading: Scene " + ArenaSceneIndex[currentIndex]);
    }
}

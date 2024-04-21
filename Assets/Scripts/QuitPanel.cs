using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : MonoBehaviour
{
    // Reference BattleSystem script
    BattleSystem bs;

    // Reference SaveLoad script
    SaveLoad SL;

    void Start()
    {
        // Find component
        bs = GetComponent<BattleSystem>();
        SL = GetComponent<SaveLoad>();
    }


    public void ConfrimQuitToMenu()
    {
        Debug.Log("[QUIT PANEL/REWARDS]: " + bs.TempGems + " " + bs.TempMoney);

        // Add rewards for battle
        bs.PlayableCharacter.PlayerMoney += bs.TempMoney;
        bs.PlayableCharacter.PlayerGem += bs.TempGems;
        bs.PlayableCharacter.PlayerXP += bs.TempXP;

        // Save rewards to player
        bs.PlayableCharacter.SavePlayer();

        Debug.Log("[QUIT PANEL/REWARDS]: Added M/G - " + bs.TempMoney + "/" + bs.TempGems);
        Debug.Log("[QUIT PANEL/REWARDS]: New balance - " + bs.PlayableCharacter.PlayerMoney);
        Debug.Log("[QUIT PANEL/REWARDS]: New balance - " + bs.PlayableCharacter.PlayerGem);

        // Save rewards to json
        SL.SaveToJson();

        // Load back into main menu scene (index 0)
        SceneManager.LoadScene(0);
    }

    public void ConfirmQuitGame()
    {
        // Shutdown the whole game
        // Soon :3
    }
}

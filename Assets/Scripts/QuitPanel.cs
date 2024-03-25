using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : MonoBehaviour
{
    public void ConfrimQuitToMenu()
    {
        // Load back into main menu scene (index 0)
        SceneManager.LoadScene(0);
    }

    public void ConfirmQuitGame()
    {
        // Shutdown the whole game
        // Soon :3
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamesettings : MonoBehaviour
{
    private string lastScene;

    void Start()
    {
        lastScene = PlayerPrefs.GetString("LastScene", "GameMode1scene");
    }

    public void OpenSettings()
    {
        Time.timeScale = 0f; 
        PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("GameSettingsScene");
    }

    public void ReturnToGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(lastScene);
    }
}

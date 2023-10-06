using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneMethod : MonoBehaviour
{
    public void loadCustomizeScene(){
        SceneManager.LoadScene("customizationScene");
    }

    public void loadProfileScene(){
        SceneManager.LoadScene("profileScene");
    }

    public void loadShopScene(){
        SceneManager.LoadScene("shopScene");
    }

    public void loadSettingsScene(){
        SceneManager.LoadScene("settingsScene");
    }

    public void loadPlayScene(){
        SceneManager.LoadScene("playScene");
    }

    public void loadGameMode1Scene(){
        SceneManager.LoadScene("GameMode1Scene");
    }

    public void loadAudioScene(){
        SceneManager.LoadScene("AudioScene");
    }

    public void backToLobby(){
        SceneManager.LoadScene("lobbyScene");
    }

    public void callMethod(){
        Debug.Log("Mode 2 opened");
    }

    public void logoutToLogin(){
        SceneManager.LoadScene("loginScene");
    }

    public void backToSettings(){
        SceneManager.LoadScene("settingsScene");
    }

}

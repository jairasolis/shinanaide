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
        SceneManager.LoadScene("gameloading");
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

    public void loginToRegister(){
        SceneManager.LoadScene("registerScene");
    }

    public void registerToLogin(){
        SceneManager.LoadScene("loginScene");
    }

    public void logoutToLogin(){
        SceneManager.LoadScene("loginScene");
    }

    public void GameSettingsScene()
    {
        SceneManager.LoadScene("GamesettingsScene");
    }

    public void loadPuckScene(){
        SceneManager.LoadScene("puckScene");
    }

    public void loadMapScene(){
        SceneManager.LoadScene("mapScene");
    }

    public void loadCharacterScene(){
        SceneManager.LoadScene("customizationScene");
    }

    public void loadGameSettingtwoScene()
    {
        SceneManager.LoadScene("GamesettingsScene");
    }

    public void loadAudiotwoScene()
    {
        SceneManager.LoadScene("AudioSettings");
    }
    public void loadWaitingScene()
    {
        SceneManager.LoadScene("waitingScene");
    }

    public void loadMatchmakingScene()
    {
        SceneManager.LoadScene("matchmakingScene");
    }

}


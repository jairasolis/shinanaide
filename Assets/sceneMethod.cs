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

    public void backToLobby(){
        Debug.Log("BackToLobby called");
        SceneManager.LoadScene(1);
    }

    public void callMethod(){
        Debug.Log("Mode 2 opened");
    }
}

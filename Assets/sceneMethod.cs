using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneMethod : MonoBehaviour
{
    public void loadCustomizeScene(){
        SceneManager.LoadScene(4);
    }

    public void loadProfileScene(){
        SceneManager.LoadScene(5);
    }


    public void loadShopScene(){
        SceneManager.LoadScene(6);
    }

    public void loadSettingsScene(){
        SceneManager.LoadScene(7);
    }

    public void backToLobby(){
        Debug.Log("BackToLobby called");
        SceneManager.LoadScene(3);
    }

    public void callMethod(){
        Debug.Log("Mode 2 opened");
    }
}

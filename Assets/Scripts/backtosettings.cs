using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backtosettings : MonoBehaviour
{
    public void backToLobby()
    {
        SceneManager.LoadScene("settingScene");
    }
}

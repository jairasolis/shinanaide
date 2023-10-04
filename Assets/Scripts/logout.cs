using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logout : MonoBehaviour
{
    public void logoutToLogin()
    {
        Debug.Log("LogoutToLogin called");
        SceneManager.LoadScene(1);
    }
}
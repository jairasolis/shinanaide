using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{

    public InputField usernameInput;
    public InputField passwordInput;
    public Button loginButton;
    public Button goToRegisterButton;

    ArrayList credentials;

    // Start is called before the first frame update
    void Start()
    {
        loginButton.onClick.AddListener(login);
        goToRegisterButton.onClick.AddListener(moveToRegister);

        if (File.Exists(Application.dataPath + "/credentials.txt"))
        {
            credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/credentials.txt"));
        }
        else
        {
            Debug.Log("Credential file doesn't exist");
        }

    }



    // Update is called once per frame
    void login()
    {
        bool isExists = false;

        credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/credentials.txt"));

        foreach (var i in credentials)
        {
            string line = i.ToString();
            int indexOfColon = line.IndexOf(":");

            if (indexOfColon >= 0)
            {
                string username = line.Substring(0, indexOfColon);
                string password = line.Substring(indexOfColon + 1);

                if (username.Equals(usernameInput.text) && password.Equals(passwordInput.text))
                {
                    isExists = true;
                    break;
                }
            }
        }

        if (isExists)
        {
            Debug.Log($"Logging in '{usernameInput.text}'");
            loadLoadingScene();
        }
        else
        {
            Debug.Log("Incorrect credentials");
        }
    }


    void moveToRegister()
    {
        SceneManager.LoadScene("registerScene");
    }

    void loadLoadingScene()
    {
        SceneManager.LoadScene("LoadingScene");
    }
}

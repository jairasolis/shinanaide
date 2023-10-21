using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class loginScript : MonoBehaviour
{

    public InputField usernameInput;
    public InputField passwordInput;
    public Button loginButton;
    public TextMeshProUGUI loginStatusText;


    void Start()
    {
        loginButton.onClick.AddListener(() =>
        {
            if (usernameInput.text == "" || passwordInput.text == "")
            {
                loginStatusText.gameObject.SetActive(true);
                loginStatusText.text = "Error detected. Field is null. Please try again.";
            }
            else
            {
                StartCoroutine(main.Instance.Web.loginUser(usernameInput.text, passwordInput.text));
                PlayerPrefs.SetString("LoggedInUsername", usernameInput.text); // Store the username in PlayerPrefs
                StartCoroutine(main.Instance.Web.getInfo(usernameInput.text));

                PlayerPrefs.Save(); // Save the PlayerPrefs data
            }
        });
    }

    public void UpdateLoginStatus(string status)
    {
        loginStatusText.gameObject.SetActive(true);
        loginStatusText.text = status;

        if (status == "Login success.")
        {
            // Load a new scene when login is successful
            SceneManager.LoadScene("LoadingScene");
        }
    }

}

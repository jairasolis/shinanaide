using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class login : MonoBehaviour
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
            }
        });
    }
}

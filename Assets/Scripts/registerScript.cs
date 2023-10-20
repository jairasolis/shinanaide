using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class registerScript : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    public InputField confirmPasswordInput;

    public Button registerButton;
    public TextMeshProUGUI registerStatusText;

    void Start()
    {
        registerButton.onClick.AddListener(() =>
        {
            if (usernameInput.text == "" || passwordInput.text == "")
            {
                registerStatusText.gameObject.SetActive(true);
                registerStatusText.text = "Error detected. Field is null. Please try again.";
            }
            else if (passwordInput.text == confirmPasswordInput.text)
            {
                StartCoroutine(main.Instance.Web.registerUser(usernameInput.text, passwordInput.text));
            }
            else
            {
                registerStatusText.gameObject.SetActive(true);
                registerStatusText.text = "Password did not match.";
            }
        });
    }

    public void UpdateRegisterStatus(string status)
    {
        registerStatusText.gameObject.SetActive(true);
        registerStatusText.text = status;

        if (status == "success")
        {
            // Load a new scene when register is successful
            SceneManager.LoadScene("loginScene");
        }
    }
}

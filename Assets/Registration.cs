using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class Registration : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);

        UnityWebRequest www = UnityWebRequest.Post("https://shinanaide.000webhostapp.com/register.php", form);

        yield return www.SendWebRequest(); ;

        if (www.downloadHandler.text == "0")
        {
            Debug.Log("User Created Succesfully");
            UnityEngine.SceneManagement.SceneManager.LoadScene("loginScene");
        }
        else
        {
            Debug.Log("User Creation Failed. Error #" + www.downloadHandler.text);
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }
}
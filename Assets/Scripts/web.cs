using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class web : MonoBehaviour
{

    private loginScript loginScript;
    private registerScript registerScript;

    void Start()
    {

        loginScript = GetComponent<loginScript>();
        registerScript = GetComponent<registerScript>();
        //StartCoroutine(GetDate());
        //StartCoroutine(GetUser());
        //StartCoroutine(login("akemi", "akemipasss"));
        //StartCoroutine(registerUser("aaaa", "aaaa"));
    }

    public IEnumerator GetDate()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/unityScript/getDate.php"))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                byte[] results = www.downloadHandler.data;
            }
        }
    }

    public IEnumerator GetUser()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("https://shinanaide.000webhostapp.com/getUsers.php"))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                byte[] results = www.downloadHandler.data;
            }
        }
    }

    public IEnumerator loginUser(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        UnityWebRequest www = UnityWebRequest.Post("https://shinanaide.000webhostapp.com/login.php", form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            string response = www.downloadHandler.text;
            Debug.Log(response);
            loginScript.UpdateLoginStatus(response); // Update the login status
        }
    }

    public IEnumerator registerUser(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        UnityWebRequest www = UnityWebRequest.Post("https://shinanaide.000webhostapp.com/register.php", form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            string response = www.downloadHandler.text;
            Debug.Log(response);
            registerScript.UpdateRegisterStatus(response); // update the login status
        }
    }
}
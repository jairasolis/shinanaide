using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class web : MonoBehaviour
{
        
    private loginScript loginScript;
    private registerScript registerScript;
    private lobbyDBScript lobbyDBScript;
    private profileDB profileDB;

    public string lobbyUsername;
    public string lobbyGambas;
    public string wins;
    public string icon;

    void Start()
    {
        
        loginScript = GetComponent<loginScript>();
        registerScript = GetComponent<registerScript>();
        lobbyDBScript = GetComponent<lobbyDBScript>();
        profileDB = GetComponent<profileDB>();
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
            //main.Instance.userInfo.setInfo(username, password);


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

    public IEnumerator getInfo(string username)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        //form.AddField("loginPass", password);

        UnityWebRequest www = UnityWebRequest.Post("https://shinanaide.000webhostapp.com/getInfo.php", form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            string s = www.downloadHandler.text;
            Debug.Log(s);
            
            lobbyUsername = s.Split('-')[0];
            lobbyGambas = s.Split("-")[1];
            wins = s.Split("-")[2];
            icon = s.Split("-")[3];


            PlayerPrefs.SetString("userGambas", lobbyGambas); // Store the username in PlayerPrefs
            PlayerPrefs.Save(); // Save the PlayerPrefs data

            PlayerPrefs.SetString("userWins", wins); // Store the username in PlayerPrefs
            PlayerPrefs.Save(); // Save the PlayerPrefs data

            PlayerPrefs.SetString("userIcon", icon); // Store the username in PlayerPrefs
            PlayerPrefs.Save(); // Save the PlayerPrefs data

            profileDB.UpdateUserProfileImage(icon);

            Debug.Log(icon);

            //lobbyDBScript.UpdateInfo(lobbyUsername, lobbyGambas);

            //Debug.Log(lobbyUsername);
            //Debug.Log(lobbyGambas);
            //Debug.Log(wins);

        }
    }

    public IEnumerator updateIcon(string iconpath)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", PlayerPrefs.GetString("LoggedInUsername"));
        form.AddField("loginIcon", iconpath);

        UnityWebRequest www = UnityWebRequest.Post("https://shinanaide.000webhostapp.com/updateIcon.php", form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            string response = www.downloadHandler.text;
            Debug.Log(response);

            //profileDB.UpdateUserProfileImage(response);


            PlayerPrefs.SetString("updatedIcon", response); // Store the username in PlayerPrefs
            PlayerPrefs.Save(); // Save the PlayerPrefs data
        }
    }

    public IEnumerator updateGambasWins()
    {
        Debug.Log("gambas updated");

        WWWForm form = new WWWForm();
        form.AddField("loginUser", PlayerPrefs.GetString("LoggedInUsername"));

        UnityWebRequest www = UnityWebRequest.Post("https://shinanaide.000webhostapp.com/updateGambasWins.php", form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            string response = www.downloadHandler.text;
            Debug.Log(response);

            //profileDB.UpdateUserProfileImage(response);
        }
    }
}
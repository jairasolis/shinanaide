using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Networking;


public class lobbyDBScript : MonoBehaviour
{
    public TextMeshProUGUI usernameText;
    public TextMeshProUGUI gambasText;
    public GameObject userlobbyimage;

    public string lobbyGambas;

    void Start()
    {

        string username = PlayerPrefs.GetString("LoggedInUsername");
        StartCoroutine(getInfo(username));
        usernameText.text = username;

        string gambas = PlayerPrefs.GetString("userGambas");
        gambasText.text = gambas;

        userlobbyimage.GetComponent<Image>().sprite = LoadSpriteFromPath(PlayerPrefs.GetString("updatedIcon"));
    }

    private Sprite LoadSpriteFromPath(string path)
    {
        Sprite loadedSprite = Resources.Load<Sprite>(path);

        if (loadedSprite == null)
        {
            Debug.LogError("Failed to load sprite at path: " + path);
        }

        return loadedSprite;
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

            lobbyGambas = s.Split("-")[1];

            PlayerPrefs.SetString("userGambas", lobbyGambas); 
            PlayerPrefs.Save(); 


        }
    }

}

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

    void Start()
    {

        string username = PlayerPrefs.GetString("LoggedInUsername");
        //StartCoroutine(main.Instance.Web.getInfo(username));
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

}

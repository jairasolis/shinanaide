using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class profileDB : MonoBehaviour
{
    public GameObject[] icons;
    public GameObject iconsPanel;
    public GameObject userprofileimage;
    public TextMeshProUGUI winsNum;
    public TextMeshProUGUI textname;


    void Start()
    {
        string usernameP = PlayerPrefs.GetString("LoggedInUsername");
        textname.text = usernameP;
        winsNum.text = PlayerPrefs.GetString("userWins");
        //StartCoroutine(main.Instance.Web.getInfo(usernameP));
        userprofileimage.GetComponent<Image>().sprite = LoadSpriteFromPath(PlayerPrefs.GetString("updatedIcon"));
    }

    public void UpdateUserProfileImage(string iconpath)
    {
        userprofileimage.GetComponent<Image>().sprite = LoadSpriteFromPath(iconpath);
    }

    public void image1()
    {
        Debug.Log("Image1 button clicked");
        StartCoroutine(main.Instance.Web.updateIcon("payr"));
        //StartCoroutine(main.Instance.Web.getInfo(PlayerPrefs.GetString("LoggedInUsername")));
        UpdateUserProfileImage("payr");
    }

    public void image2()
    {
        Debug.Log("Image2 button clicked");
        StartCoroutine(main.Instance.Web.updateIcon("watur"));
        UpdateUserProfileImage("watur");
    }

    public void image3()
    {
        Debug.Log("Image3 button clicked");
        //StoreIcon("ert");
        StartCoroutine(main.Instance.Web.updateIcon("ert"));
        //StartCoroutine(main.Instance.Web.getInfo(PlayerPrefs.GetString("LoggedInUsername")));
        UpdateUserProfileImage("ert");
    }

    public void image4()
    {
        Debug.Log("Image4 button clicked");
        //StoreIcon("perpulap");
        StartCoroutine(main.Instance.Web.updateIcon("perpulap"));
        //StartCoroutine(main.Instance.Web.getInfo(PlayerPrefs.GetString("LoggedInUsername")));
        UpdateUserProfileImage("perpulap");
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

    // buttons in profile

    public void displayIconsPopUp()
    {
        iconsPanel.SetActive(true);
    }

    public void closePopUp()
    {

        iconsPanel.SetActive(false);
    }

    public void applyIcon()
    {
        iconsPanel.SetActive(false);
    }
}

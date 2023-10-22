using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Networking;


public class shopDB : MonoBehaviour
{
    public TextMeshProUGUI gambasText;
    public ShopManager ShopManager;

    void Start()
    {
        string gambas = PlayerPrefs.GetString("userGambas");
        gambasText.text = gambas;
        ShopManager.CheckPurchaseable();

    }

    public void insertItem(int item)
    {
        StartCoroutine(insertItemID(item));
    }


    public void item1()
    {
        insertItem(1);
    }

    public void item2()
    {
        insertItem(2);
    }

    public void item3()
    {
        insertItem(3);
    }

    public void item4()
    {
        insertItem(4);
    }

    public void item5()
    {
        insertItem(5);
    }

    public IEnumerator insertItemID(int itemID)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", PlayerPrefs.GetString("LoggedInUsername"));
        form.AddField("loginItemID", itemID);

        UnityWebRequest www = UnityWebRequest.Post("https://shinanaide.000webhostapp.com/insertItemID.php", form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            string response = www.downloadHandler.text;
            Debug.Log(response);
        }
    }


}

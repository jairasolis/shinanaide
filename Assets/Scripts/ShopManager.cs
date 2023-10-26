using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Networking;


public class ShopManager : MonoBehaviour
{
    public int gambas;
    public TMP_Text gambasUI;
    public ShopItemSO[] shopItemsSO;
    public GameObject[] shopPanelsGO;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseBtns;
    public TextMeshProUGUI gambasText;


    public string lobbyUsername;
    public string lobbyGambas;
    public string wins;
    public string icon;

    void Start()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
            shopPanelsGO[i].SetActive(true);

        LoadPanels();
        CheckPurchaseable();

        string gambas = PlayerPrefs.GetString("userGambas");
        gambasText.text = gambas;
    }

    public void AddGambas()
    {
        gambas++;
        gambasUI.text = gambas.ToString();
        CheckPurchaseable();
    }
    
    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (gambas >= shopItemsSO[i].baseCost)
                myPurchaseBtns[i].interactable = true;
            else
                myPurchaseBtns[i].interactable = false;
        }
    }
    
    
    public void PurchaseItem(int btnNo)
    {
        if (gambas >= shopItemsSO[btnNo].baseCost)
        {
            gambas = gambas - shopItemsSO[btnNo].baseCost;
            gambasUI.text = "Gambas: " + gambas.ToString();
            CheckPurchaseable();
        }
    }
    
    
    public void LoadPanels()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanels[i].titleTxt.text = shopItemsSO[i].title;
            shopPanels[i].descriptionTxt.text = shopItemsSO[i].description;
            shopPanels[i].costTxt.text = shopItemsSO[i].baseCost.ToString();
        }
    }

    public void insertItem(int item)
    {
        StartCoroutine(insertItemID(item));

        //for (int i = 0; i < shopItemsSO.Length; i++)
        //{
        //    if (gambas >= shopItemsSO[i].baseCost)
        //        StartCoroutine(insertItemID(item));
        //    else
        //        Debug.Log("Not enough gambas");
        //}
    }


    public void item1()
    {
        CheckPurchaseable();
        insertItem(1);
        StartCoroutine(purchase());
        StartCoroutine(getInfo());

    }

    public void item2()
    {
        CheckPurchaseable();
        insertItem(2);
        StartCoroutine(purchase());
        StartCoroutine(getInfo());

    }

    public void item3()
    {
        CheckPurchaseable();
        insertItem(3);
        StartCoroutine(purchase());
        StartCoroutine(getInfo());

    }

    public void item4()
    {
        CheckPurchaseable();
        insertItem(4);
        StartCoroutine(purchase());
        StartCoroutine(getInfo());

    }

    public void item5()
    {
        CheckPurchaseable();
        insertItem(5);
        StartCoroutine(purchase());
        StartCoroutine(getInfo());

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

    public IEnumerator purchase()
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", PlayerPrefs.GetString("LoggedInUsername"));

        UnityWebRequest www = UnityWebRequest.Post("https://shinanaide.000webhostapp.com/purchase.php", form);
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

    public IEnumerator getInfo()
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", PlayerPrefs.GetString("LoggedInUsername"));
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


            Debug.Log(icon);

            //lobbyDBScript.UpdateInfo(lobbyUsername, lobbyGambas);

            //Debug.Log(lobbyUsername);
            //Debug.Log(lobbyGambas);
            //Debug.Log(wins);

        }

    }

        // sqlite database

        //public void updateGambas()
        //{
        //    string username = PlayerPrefs.GetString("LoggedInUsername"); // Get the logged-in username


        //    string databasePath = Application.dataPath + "/accountDB.db";
        //    string connectionString = "URI=file:" + databasePath;

        //    using (var connection = new SqliteConnection(connectionString))
        //    {
        //        connection.Open();

        //        using (var command = connection.CreateCommand())
        //        {
        //            // Select the iconPath for the logged-in user
        //            command.CommandText = "SELECT gambas FROM account WHERE username = @username";
        //            command.Parameters.Add(new SqliteParameter("@username", username));

        //            using (var reader = command.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    int gambasValue = reader.GetInt32(0);

        //                    Debug.Log("gambas retrieved from the database: " + gambasValue);

        //                    // Now you have the 'iconPath' from the database. You can use it to load and display the icon in your UI.
        //                    // For example, you can assign it to a UI Image component like this:
        //                    gambasNum.text = gambasValue.ToString();
        //                }
        //                else
        //                {
        //                    Debug.LogError("User's icon not found in the database.");
        //                }
        //            }
        //        }
        //    }
        //}
}

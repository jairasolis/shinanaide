using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mono.Data.Sqlite;
using System.Data;

public class ShopManager : MonoBehaviour
{
    public int gambas;
    public TMP_Text gambasUI;
    public ShopItemSO[] shopItemsSO;
    public GameObject[] shopPanelsGO;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseBtns;
    public TextMeshProUGUI gambasNum;


    void Start()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
            shopPanelsGO[i].SetActive(true);
        gambasUI.text = gambas.ToString();
        LoadPanels();
        CheckPurchaseable();
        updateGambas();
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

    public void updateGambas()
    {
        string username = PlayerPrefs.GetString("LoggedInUsername"); // Get the logged-in username


        string databasePath = Application.dataPath + "/accountDB.db";
        string connectionString = "URI=file:" + databasePath;

        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                // Select the iconPath for the logged-in user
                command.CommandText = "SELECT gambas FROM account WHERE username = @username";
                command.Parameters.Add(new SqliteParameter("@username", username));

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int gambasValue = reader.GetInt32(0);

                        Debug.Log("gambas retrieved from the database: " + gambasValue);

                        // Now you have the 'iconPath' from the database. You can use it to load and display the icon in your UI.
                        // For example, you can assign it to a UI Image component like this:
                        gambasNum.text = gambasValue.ToString();
                    }
                    else
                    {
                        Debug.LogError("User's icon not found in the database.");
                    }
                }
            }
        }
    }

}

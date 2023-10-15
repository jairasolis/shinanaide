using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using Mono.Data.Sqlite;
using System.Data;
using System.Collections;
using System.Collections.Generic;

public class Profile : MonoBehaviour
{    
    public GameObject[] icons;
    public GameObject iconsPanel;
    public GameObject userprofileimage;
    public TextMeshProUGUI winsNum;


    void Start()
    {
    }

    void Update()
    {
    }



    public void image1()
    {
        Debug.Log("Image1 button clicked");
        StoreIcon("payr");
        UpdateUserProfileImage();
    }

    public void image2()
    {
        Debug.Log("Image2 button clicked");
        StoreIcon("watur");
        UpdateUserProfileImage();
    }

    public void image3()
    {
        Debug.Log("Image3 button clicked");
        StoreIcon("ert");
        UpdateUserProfileImage();
    }

    public void image4()
    {
        Debug.Log("Image4 button clicked");
        StoreIcon("perpulap");
        UpdateUserProfileImage();
    }

    public void UpdateUserProfileImage()
    {
        string username = PlayerPrefs.GetString("LoggedInUsername"); // Get the logged-in username
        Debug.Log("UpdateUserProfileImage called for user: " + username);

        if (string.IsNullOrEmpty(username))
        {
            Debug.LogError("No logged-in username found.");
            return;
        }

        string databasePath = Application.dataPath + "/accountDB.db";
        string connectionString = "URI=file:" + databasePath;

        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                // Select the iconPath for the logged-in user
                command.CommandText = "SELECT icon, wins FROM account WHERE username = @username";
                command.Parameters.Add(new SqliteParameter("@username", username));

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string iconPath = reader.GetString(0);
                        int winsValue = reader.GetInt32(1); // Retrieve wins as an integer

                        Debug.Log("Icon path retrieved from the database: " + iconPath);
                        Debug.Log("Wins value retrieved from the database: " + winsValue);

                        // Now you have the 'iconPath' from the database. You can use it to load and display the icon in your UI.
                        // For example, you can assign it to a UI Image component like this:
                        userprofileimage.GetComponent<Image>().sprite = LoadSpriteFromPath(iconPath);
                        winsNum.text = winsValue.ToString();
                    }
                    else
                    {
                        Debug.LogError("User's icon not found in the database.");
                    }
                }
            }
        }
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



    public void StoreIcon(string iconName)
    {
        string iconPath = iconName;
        string databasePath = Application.dataPath + "/accountDB.db";
        string connectionString = "URI=file:" + databasePath;

        using (var connection = new SqliteConnection("URI=file:" + Application.dataPath + "/accountDB.db"))
        {
            connection.Open();

            using (var transaction = connection.BeginTransaction())
            {
                var command = connection.CreateCommand();
                command.Transaction = transaction;

                // Update the icon for a specific user (filtered by username)
                command.CommandText = "UPDATE account SET icon = @icon WHERE username = @username";

                command.Parameters.Add(new SqliteParameter("@icon", iconPath));
                string username = PlayerPrefs.GetString("LoggedInUsername");
                command.Parameters.Add(new SqliteParameter("@username", username));
                UpdateUserProfileImage();
                Debug.Log(iconPath + username);

                command.ExecuteNonQuery();

                transaction.Commit();
            }
        }
    }


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
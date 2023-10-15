
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Data;
using Mono.Data.Sqlite;

public class profileU : MonoBehaviour
{
    public GameObject userprofileimage;
    public TextMeshProUGUI textname;

    void Start()
    {

        string username = PlayerPrefs.GetString("LoggedInUsername"); // Get the logged-in username
        textname.text = username;

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

                        userprofileimage.GetComponent<Image>().sprite = LoadSpriteFromPath(iconPath);
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
}
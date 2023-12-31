using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mono.Data.Sqlite;
using System.Data;

public class scoreWinsToDB : MonoBehaviour
{
    public void add()
    {
        addGambas();
        addWin();
    }

    public void addGambas()
    {
        string username = PlayerPrefs.GetString("LoggedInUsername");

        string databasePath = Application.dataPath + "/accountDB.db";
        string connectionString = "URI=file:" + databasePath;

        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            using (var transaction = connection.BeginTransaction())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE account SET gambas = gambas + 3 WHERE username = @username";

                    command.Parameters.Add(new SqliteParameter("@username", username));

                    int rowsUpdated = command.ExecuteNonQuery();

                    if (rowsUpdated > 0)
                    {
                        transaction.Commit();
                        Debug.Log("Wins updated for user: " + username);
                    }
                    else
                    {
                        transaction.Rollback(); 
                        Debug.LogError("Failed to update wins for user: " + username);
                    }
                }
            }
        }
    }

    public void addWin()
    {
        string username = PlayerPrefs.GetString("LoggedInUsername");

        string databasePath = Application.dataPath + "/accountDB.db";
        string connectionString = "URI=file:" + databasePath;

        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            using (var transaction = connection.BeginTransaction())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE account SET wins = wins + 1 WHERE username = @username";

                    command.Parameters.Add(new SqliteParameter("@username", username));

                    int rowsUpdated = command.ExecuteNonQuery();

                    if (rowsUpdated > 0)
                    {
                        transaction.Commit(); 
                        Debug.Log("Wins updated for user: " + username);
                    }
                    else
                    {
                        transaction.Rollback();
                        Debug.LogError("Failed to update wins for user: " + username);
                    }
                }
            }
        }
    }
}

using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using UnityEngine.SceneManagement;

public class DBaccount : MonoBehaviour
{

    public Button goToLoginButton;


    string conn;
    string sqlQuery;
    IDbConnection dbconn;
    IDbCommand dbcmd;

    public InputField usernameInput;
    public InputField passwordInput;
    
    string DATABASE_NAME = "/accountDB.db";

    void Start()
    {
        string filepath = Application.dataPath + DATABASE_NAME;
        conn = "URI=file:" + filepath;
        dbconn = new SqliteConnection(conn);
        CreateTable();
    }

    private void CreateTable()
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();

            sqlQuery = "CREATE TABLE IF NOT EXISTS account (username TEXT NOT NULL, password TEXT NOT NULL, icon TEXT NOT NULL DEFAULT 'payr', gambas INT NOT NULL DEFAULT 0, wins INT NOT NULL DEFAULT 0);";

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }


    public void AddAccount()
    {
        using (var connection = new SqliteConnection(conn))
        {
            connection.Open();

            using (var transaction = connection.BeginTransaction())
            {
                var command = connection.CreateCommand();
                command.Transaction = transaction;
                command.CommandText = "INSERT INTO account (username, password) VALUES (@username, @password)";
                command.Parameters.Add(new SqliteParameter("@username", usernameInput.text));
                command.Parameters.Add(new SqliteParameter("@password", passwordInput.text));
                command.ExecuteNonQuery();

                transaction.Commit();
            }
        }

        Debug.Log("Account is saved to the DB");
    }


    void Starts()
    {
        goToLoginButton.onClick.AddListener(goToLoginScene);
    }

    public void goToLoginScene()
    {
        SceneManager.LoadScene("loginScene");
    }

    
}

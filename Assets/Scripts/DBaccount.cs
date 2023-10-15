using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using UnityEngine.SceneManagement;
using TMPro;


public class DBaccount : MonoBehaviour
{

    public Button goToLoginButton;


    string conn;
    string sqlQuery;
    string shop;
    string inventory;
    IDbConnection dbconn;
    IDbCommand dbcmd;

    public InputField usernameInput;
    public InputField passwordInput;
    public InputField confirmPassInput;
    public TextMeshProUGUI registerStatusText;



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
            shop = "CREATE TABLE IF NOT EXISTS shop (character TEXT NOT NULL, ball TEXT NOT NULL, court TEXT NOT NULL);";
            inventory = "CREATE TABLE IF NOT EXISTS inventory (character TEXT NOT NULL, ball TEXT NOT NULL, court TEXT NOT NULL);";


            dbcmd.CommandText = sqlQuery;
            dbcmd.CommandText = shop;
            dbcmd.CommandText = inventory;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }


    public void AddAccount()
    {
        if (usernameInput.text == "" || passwordInput.text == "")
        {
            registerStatusText.gameObject.SetActive(true);
            registerStatusText.text = "Error detected. Field is null. Please try again.";
        }
        else if (passwordInput.text == confirmPassInput.text)
        {
            goToLoginScene();

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
        else
        {
            registerStatusText.gameObject.SetActive(true);
            registerStatusText.text = "Password did not match.";
        }
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
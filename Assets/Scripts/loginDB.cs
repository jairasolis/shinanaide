using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class loginDB : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    public TextMeshProUGUI loginStatusText;

    string DATABASE_NAME = "/accountDB.db";
    string conn;
    IDbConnection dbconn;

    void Start()
    {
        string filepath = Application.dataPath + DATABASE_NAME;
        conn = "URI=file:" + filepath;
        dbconn = new SqliteConnection(conn);
    }

    public void AttemptLogin()
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            using (IDbCommand dbcmd = dbconn.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM account WHERE username = @username AND password = @password";
                dbcmd.CommandText = sqlQuery;

                IDbDataParameter paramUsername = dbcmd.CreateParameter();
                paramUsername.ParameterName = "@username";
                paramUsername.Value = usernameInput.text;
                dbcmd.Parameters.Add(paramUsername);
                GetUsername(usernameInput.text);

                IDbDataParameter paramPassword = dbcmd.CreateParameter();
                paramPassword.ParameterName = "@password";
                paramPassword.Value = passwordInput.text;
                dbcmd.Parameters.Add(paramPassword);

                IDataReader reader = dbcmd.ExecuteReader();

                if (usernameInput.text == "" || passwordInput.text == "")
                {

                    loginStatusText.gameObject.SetActive(true);
                    loginStatusText.text = "Error detected. Field is null. Please try again.";

                }else if(reader.Read())
                {
                    PlayerPrefs.SetString("LoggedInUsername", usernameInput.text); // Store the username in PlayerPrefs
                    PlayerPrefs.Save(); // Save the PlayerPrefs data

                    loadLoadingScene();
                }
                else
                {
                    loginStatusText.gameObject.SetActive(true);
                    loginStatusText.text = "Login failed. Invalid username or password.";
                }

                reader.Close();
            }
            dbconn.Close();
            //return username;
        }
    }

    public string GetUsername(string username)
    {
        return username; 
    }

    void loadLoadingScene()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    public void GoToRegisterScene()
    {
        SceneManager.LoadScene("registerScene");
    }
}

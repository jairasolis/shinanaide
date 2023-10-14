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

                IDbDataParameter paramPassword = dbcmd.CreateParameter();
                paramPassword.ParameterName = "@password";
                paramPassword.Value = passwordInput.text;
                dbcmd.Parameters.Add(paramPassword);

                IDataReader reader = dbcmd.ExecuteReader();

                if (reader.Read())
                {
                    PlayerPrefs.SetString("LoggedInUsername", usernameInput.text); // Store the username in PlayerPrefs
                    PlayerPrefs.Save(); // Save the PlayerPrefs data
                    loadLoadingScene();
                    // loadProfileScene(); // Transition to the profile scene
                }
                else
                {
                    loginStatusText.gameObject.SetActive(true);
                    loginStatusText.text = "Login failed. Invalid username or password.";
                }

                reader.Close();
            }
            dbconn.Close();
        }
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

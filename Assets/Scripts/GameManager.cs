using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public float totalTime = 60f;
    private float timeRemaining;

    [SerializeField]
    private TextMeshProUGUI timerText;

    [SerializeField]
    private TextMeshProUGUI player1ScoreText;

    [SerializeField]
    private TextMeshProUGUI player2ScoreText;

    [SerializeField]
    private TextMeshProUGUI resultText;

    private int player1Score = 0;
    private int player2Score = 0;

    private bool isRespawning = false;
    private float respawnCountdown = 3f;
    private AI aiObject; 

    public Transform player1RespawnPoint;
    public Transform player2RespawnPoint;
    public Transform RespawnPointPuck;
    scoreWinsToDB wintoDB;

    void Start()
    {
        timeRemaining = totalTime;
        UpdateTimerDisplay();
        UpdatePlayerScores();
        aiObject = GameObject.FindGameObjectWithTag("Player2").GetComponent<AI>();
        wintoDB = GameObject.FindGameObjectWithTag("needed").GetComponent<scoreWinsToDB>();
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            DetermineWinner();
        }
        if (isRespawning)
        {
            respawnCountdown -= Time.deltaTime;

            if (respawnCountdown <= 0f)
            {
                RespawnPlayers();
                RespawnPuck();
                respawnCountdown = 3f;
                isRespawning = false;
                aiObject.SetShouldFollowPuck(true);
                aiObject.SetGameInProgress(true);
            }
        }
    }

    void UpdateTimerDisplay()
    {
        timeRemaining = Mathf.Max(timeRemaining, 0f);

        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void UpdatePlayerScores()
    {
        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();
    }

    void DetermineWinner()
    {
        if (player1Score > player2Score)
        {
            resultText.text = "Player 1 Wins!";
            WinScene();
        }
        else if (player2Score > player1Score)
        {
            resultText.text = "Player 2 Wins!";
            WinScene();
        }
        else
        {
            resultText.text = "It's a Tie!";
            WinScene();
        }
    }

    public void Player1Scores()
    {
        if (player1Score < 7 && !isRespawning)
        {
            player1Score++;
            UpdatePlayerScores();
            CheckWinCondition();
            isRespawning = true;
            aiObject.SetShouldFollowPuck(false);
            aiObject.SetGameInProgress(false);
        }
    }

    public void Player2Scores()
    {
        if (player2Score < 7 && !isRespawning)
        {
            player2Score++;
            UpdatePlayerScores();
            CheckWinCondition();
            isRespawning = true;
            aiObject.SetShouldFollowPuck(false);
            aiObject.SetGameInProgress(false);
        }
    }

    void CheckWinCondition()
    {
        if (player1Score >= 7)
        {
            resultText.text = "Player 1 Wins!";
            wintoDB.add();
        }
        else if (player2Score >= 7)
        {
            resultText.text = "Player 2 Wins!";
        }
    }
    void WinScene()
    {
        SceneManager.LoadScene("15");
    }

    void RespawnPlayers()
    {
        GameObject player1 = GameObject.FindGameObjectWithTag("Player1");
        if (player1 != null)
        {
            player1.transform.position = player1RespawnPoint.position;
            player1.transform.rotation = player1RespawnPoint.rotation;
        }

        GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
        if (player2 != null)
        {
            player2.transform.position = player2RespawnPoint.position;
            player2.transform.rotation = player2RespawnPoint.rotation;
        }
    }

    void RespawnPuck()
    {
        GameObject Puck = GameObject.FindGameObjectWithTag("Puck");
        if (Puck != null)
        {
            Puck.transform.position = RespawnPointPuck.position;
            Puck.transform.rotation = RespawnPointPuck.rotation;
        }
    }
}

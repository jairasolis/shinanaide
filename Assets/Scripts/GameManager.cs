using UnityEngine;
using TMPro;

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

    void Start()
    {
        timeRemaining = totalTime;
        UpdateTimerDisplay();
        UpdatePlayerScores();
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
            
            if (player1Score > player2Score)
            {
                resultText.text = "Player 1 Wins!";
            }
            else if (player2Score > player1Score)
            {
                resultText.text = "Player 2 Wins!";
            }
            else
            {
                resultText.text = "It's a Tie!";
            }

           
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void UpdatePlayerScores()
    {
        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();
    }

    public void Player1Scores()
    {
        if (player1Score < 3)
        {
            player1Score++;
            UpdatePlayerScores();
            CheckWinCondition();
        }
    }

    public void Player2Scores()
    {
        if(player2Score < 3)
        {
            player2Score++;
            UpdatePlayerScores();
            CheckWinCondition();
        }
    }

    void CheckWinCondition()
    {
        if (player1Score >= 3)
        {
            resultText.text = "Player 1 Wins!";
            
        }
        else if (player2Score >= 3)
        {
            resultText.text = "Player 2 Wins!";

            
        }
    }
}

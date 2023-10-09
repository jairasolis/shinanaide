using UnityEngine;

public class GoalDetection : MonoBehaviour
{
    public GameManager gameManager;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Puck"))
        {
            if (gameObject.CompareTag("Player1Goal"))
            {
                gameManager.Player2Scores();
            }
            else if (gameObject.CompareTag("Player2Goal"))
            {
                gameManager.Player1Scores();
            }
        }
    }
}

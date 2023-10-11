using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public void RespawnPlayer(GameObject player)
    {
        player.transform.position = transform.position; 
        player.SetActive(true); 
    }

    public void RespawnPuck(GameObject puck)
    {
        puck.transform.position = transform.position;
        puck.SetActive(true); 
    }
}

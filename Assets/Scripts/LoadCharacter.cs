using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public GameObject[] puckPrefabs;
    public Transform characterSpawnPoint;
    public Transform puckSpawnPoint;

    void Start()
    {
        int selectedCharacterIndex = PlayerPrefs.GetInt("selectedCharacter");
        int selectedPuckIndex = PlayerPrefs.GetInt("selectedPuck");

        if (selectedCharacterIndex >= 0 && selectedCharacterIndex < characterPrefabs.Length)
        {
            GameObject characterPrefab = characterPrefabs[selectedCharacterIndex];
            GameObject characterClone = Instantiate(characterPrefab, characterSpawnPoint.position, Quaternion.identity);
            characterClone.tag = "Player1";

            Cinemachine.CinemachineVirtualCamera virtualCamera = GetComponent<Cinemachine.CinemachineVirtualCamera>();
            if (virtualCamera != null)
            {
                virtualCamera.Follow = characterClone.transform;
            }
        }

        if (selectedPuckIndex >= 0 && selectedPuckIndex < puckPrefabs.Length)
        {
            GameObject puckPrefab = puckPrefabs[selectedPuckIndex];
            GameObject puckClone = Instantiate(puckPrefab, puckSpawnPoint.position, Quaternion.identity);
            puckClone.tag = "Puck";
        }
    }
}

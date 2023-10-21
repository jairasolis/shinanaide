using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;

    void Start()
    {
        int selectedCharacterIndex = PlayerPrefs.GetInt("selectedCharacter");

        if (selectedCharacterIndex >= 0 && selectedCharacterIndex < characterPrefabs.Length)
        {
            GameObject prefab = characterPrefabs[selectedCharacterIndex];
            GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);

            clone.tag = "Player1";

            Cinemachine.CinemachineVirtualCamera virtualCamera = GetComponent<Cinemachine.CinemachineVirtualCamera>();
            if (virtualCamera != null)
            {
                virtualCamera.Follow = clone.transform;
            }
        }
    }
}

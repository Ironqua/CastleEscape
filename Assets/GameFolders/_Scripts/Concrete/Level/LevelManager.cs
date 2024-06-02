using UnityEngine;


public class LevelManager : MonoBehaviour
{  
    public static LevelManager Instance { get; private set; }
    
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private GameObject player;
    private GameObject currentLevel;

    void Start()
    {
        GameManager.Instance.OnGameRestart += HandleGameStart;
        GameManager.Instance.OnGameNextLevel += HandleGameNextLevel;
       HandleGameStart();
    }

    private void HandleGameStart()
    {
        ResetPlayer();
        UnloadLevel();
        LoadLevel(prefabs[0]);
    }

    private void HandleGameNextLevel()
    {
        ResetPlayer();
        UnloadLevel();
        LoadLevel(prefabs[1]);
    }

    private void LoadLevel(GameObject prefab)
    {
        currentLevel = Instantiate(prefab, Vector3.zero, Quaternion.identity);
    }

    private void UnloadLevel()
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel);
        }
    }

    private void ResetPlayer()
    {
        player.gameObject.GetComponent<PlayerInventory>().collectedKeys.Clear();
        PlayerLevelManager.Instance.ResetPlayerLevel();
        player.transform.position = new Vector3(-14f, 0, -15f);
        player.SetActive(true);
        player.GetComponent<PlayerController>().movementSpeed = 222f;
    }
}

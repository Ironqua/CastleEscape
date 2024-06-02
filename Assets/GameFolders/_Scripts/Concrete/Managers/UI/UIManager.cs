using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; set; }
    
    [SerializeField] GameObject redKeyImage;
    [SerializeField] GameObject blueKeyImage;
    
    [SerializeField] GameObject endGamePanel;
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject menuPanel;
[SerializeField] TMP_Text playerLevelText;
[SerializeField] TMP_Text levelCountText;

  int currentLevel;
    float _playerLevel;

    void Awake()
    {
        Instance = this;
    }
 
    void Start()
    {
        PlayerLevelManager.Instance.OnGetLevel += LevelManager_OnPlayerGetLevel;
        GameManager.Instance.OnGameEnd += HandleGameEnd;
        GameManager.Instance.OnGameStart += HandleGameStart;
        GameManager.Instance.OnGameRestart += HandleGameRestart;
        GameManager.Instance.OnGameNextLevel += HandleGameNextLevel;
        mainPanel.gameObject.SetActive(false);
      
     
         
    }



    private void HandleGameNextLevel()
    {
     endGamePanel.SetActive(false);
    mainPanel.SetActive(true);
     redKeyImage.SetActive(false);
     blueKeyImage.SetActive(false);
    currentLevel=2;
    levelCountText.text="Level :"+currentLevel.ToString();
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameEnd -= HandleGameEnd;
        GameManager.Instance.OnGameStart -= HandleGameStart;
        GameManager.Instance.OnGameRestart -= HandleGameRestart;
    }

    public void HandleGameRestart()
    {
    
        endGamePanel.SetActive(false);
        mainPanel.SetActive(true);
        currentLevel=1;
    levelCountText.text="Level :"+currentLevel.ToString();
     redKeyImage.SetActive(false);
     blueKeyImage.SetActive(false);
    
    }

    private void HandleGameStart()
    {
        menuPanel.SetActive(false);
        mainPanel.SetActive(true);
        currentLevel=1;
    levelCountText.text="Level :"+currentLevel.ToString();
    
    }

      private void HandleGameEnd()
    {
        StartCoroutine(ShowEndGamePanel());
    }

    private IEnumerator ShowEndGamePanel()
    {
        yield return new WaitForSecondsRealtime(1);
        endGamePanel.SetActive(true);
        mainPanel.SetActive(false);
    }

  

    private void LevelManager_OnPlayerGetLevel(float playerlevel)
    {
        _playerLevel = playerlevel;
         playerLevelText.text="Lv."+_playerLevel.ToString();
    }

    

    public void KeyImage(KeyType keyType)
    {
        if (keyType == KeyType.RedKey)
        {
            redKeyImage.SetActive(true);
        }
        else if (keyType == KeyType.BlueKey)
        {
            blueKeyImage.SetActive(true);
        }
    }
}

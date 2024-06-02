using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public event System.Action OnGameEnd;
    public event System.Action OnGameStart;
    public event System.Action OnGameRestart;

    public event System.Action OnGameNextLevel;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



      public void EndGame()
    {
        
        OnGameEnd?.Invoke(); 
        
        
    }
public void LoadGame()
{
    OnGameStart?.Invoke();
}
   
public void NextLevel()
    {
        OnGameNextLevel?.Invoke();
        // BUTTONA 
    }
    
    public void RestartGame()
    {
        OnGameRestart?.Invoke();
        // buttona
    }

    public void Qquit()
    {
        Application.Quit();
    }


   
}

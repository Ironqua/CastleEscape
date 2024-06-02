using UnityEngine;

public class PlayerLevelManager : MonoBehaviour
{
// event manager

public static PlayerLevelManager Instance;
public delegate void OnLevel(float level);
public event OnLevel OnGetLevel;


 public float _level=0;

   

void Awake()
{
    if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

}
void Update()
{
    
    OnGetLevel?.Invoke(_level);
}

public void ResetPlayerLevel()
{
    _level=0;
    OnGetLevel?.Invoke(_level);
}

 public void IncreasePlayerLevel(float amount)
    {
        _level += amount;
        OnGetLevel?.Invoke(_level);
      
    }


}

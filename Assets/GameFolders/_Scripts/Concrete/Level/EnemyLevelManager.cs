using TMPro;
using UnityEngine;

public class EnemyLevelManager : MonoBehaviour
{
    [SerializeField] public int EnemyLevel;
    [SerializeField] private TMP_Text enemyText;
    private float playerLevel;

    void Start()
    {
        PlayerLevelManager.Instance.OnGetLevel += LevelManager_OnGetLevel;
        TextLevel();  
    }

    private void LevelManager_OnGetLevel(float level)
    {
        playerLevel = level;
        TextLevel();  
    }

    private void TextLevel()
    {
        enemyText.text = "Lv." + EnemyLevel.ToString();
        enemyText.color = playerLevel >= EnemyLevel ? Color.green : Color.red;
    }
}

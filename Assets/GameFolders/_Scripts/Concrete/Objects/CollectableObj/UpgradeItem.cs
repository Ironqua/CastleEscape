using UnityEngine;

public class UpgradeItem : MonoBehaviour, ICollectable
{
    [SerializeField] float addLevelPoint;

    public void GetItem()
    {
       PlayerLevelManager.Instance.IncreasePlayerLevel(addLevelPoint);
    }
}

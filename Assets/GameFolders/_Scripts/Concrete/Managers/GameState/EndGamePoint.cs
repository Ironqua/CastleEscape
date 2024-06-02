using UnityEngine;

public class EndGamePoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.EndGame();
        }
    }
}

using System.Collections;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] GameObject particleDeadEffect;
    public static EffectManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else if (Instance != this)
        {
            Destroy(gameObject); 
        }
    }

    public void DeadEffect(Vector3 pos)
    {
        StartCoroutine(EffectDelay(pos));
    }

    IEnumerator EffectDelay(Vector3 pos)
    {
        Instantiate(particleDeadEffect, pos, Quaternion.identity);
        yield return new WaitForSeconds(1);
    }
}

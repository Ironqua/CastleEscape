using UnityEngine;

public class KeyBox : MonoBehaviour, IKeyType
{
    [SerializeField] KeyType keyType;
    public KeyType GetKey()
    {
        
        return keyType;
            
            
    }
}

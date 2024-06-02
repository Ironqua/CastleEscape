using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{ 
    
   [SerializeField] public  List<KeyType> collectedKeys = new List<KeyType>();
    
    KeyType keyType;

    void Start()
    {
        keyType = KeyType.None;
        
    }

   

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedKey") || other.CompareTag("BlueKey"))
        {
            KeyBox keyBox = other.GetComponent<KeyBox>();
            if (keyBox != null)
            {
                keyType = keyBox.GetKey();
                collectedKeys.Add(keyType);
                other.gameObject.SetActive(false);
                UIManager.Instance.KeyImage(keyType);
        }
              
            
        }
        else if(other.CompareTag("Collectable"))
        {
            ICollectable collectable=other.gameObject.GetComponent<ICollectable>();
            if(collectable!=null)
            collectable.GetItem();
            other.gameObject.SetActive(false);
        }
    }




}

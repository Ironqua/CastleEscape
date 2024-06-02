using UnityEngine;

public class DoorBox : MonoBehaviour,IDoorType
{
    PlayerInventory keyList;
   [SerializeField] HingeJointDoor doorJoint;
    [SerializeField] DoorType doorType;


    [SerializeField] float doorJointMaxValue;
    [SerializeField] float doorJointMinValue;
    public DoorType SetDoor()
    {
        
        return doorType;
    }



     void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") )
        {
              keyList = other.gameObject.GetComponent<PlayerInventory>();
            if (keyList != null)
            {
                
                UnlockDoor();
                
            }
            
        }
    }
    void UnlockDoor()
{
    switch (doorType)
    {
        case DoorType.RedDoor:
            if (keyList.collectedKeys.Contains(KeyType.RedKey))
            {
                Debug.Log("Red door unlocked");
               
               doorJoint.minValue=doorJointMinValue;
               doorJoint.maxValue=doorJointMaxValue;
            }
           
            break;

        case DoorType.BlueDoor:
            if (keyList.collectedKeys.Contains(KeyType.BlueKey))
            {
                Debug.Log("Blue door unlocked");
                  doorJoint.minValue=doorJointMinValue;
               doorJoint.maxValue=doorJointMaxValue;
               
            }
            break;

        default:
           
            break;
    }
}
  

}

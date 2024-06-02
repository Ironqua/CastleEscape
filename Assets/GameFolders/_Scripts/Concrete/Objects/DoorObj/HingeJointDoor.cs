using UnityEngine;

public class HingeJointDoor : MonoBehaviour
{
    [SerializeField] HingeJoint doorJoint;

     public float minValue; 
    public float maxValue; 

    void Update()
    {
        
        JointLimits  limits = doorJoint.limits;

        
        limits.min = minValue;
        limits.max = maxValue;

       
        doorJoint.limits = limits;
    }
}

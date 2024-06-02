using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : IMover
{
    public void MoveE(Vector3 targetPosition, Transform transform, float speed)
    {
         transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    public void MoveP(Rigidbody playerRb, Vector3 direction, float playerSpeed)
    {
       playerRb.velocity=direction*playerSpeed;
    }

    public void RotationE(Rigidbody playerRb, Transform transform, Vector3 direction, float rotateSpeed)
    {
        if (direction != Vector3.zero)
        {
            
           
          Quaternion lookRotation = Quaternion.LookRotation(direction);
          transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotateSpeed);
            
        }
        else
        {
            rotateSpeed=0;
        }
    }

    public void RotationP(Rigidbody playerRb, Transform transform, Vector3 direction, float rotateSpeed)
    {
         if (direction != Vector3.zero)
        {
            
           
            Quaternion targetRotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotateSpeed );
            
        }
        else
        {
            playerRb.angularVelocity=Vector3.zero;
        }
    }
}

using UnityEngine;

public interface IMover 
{
   void MoveE(Vector3 targetPosition, Transform transform, float speed);
 void RotationE(Rigidbody playerRb,Transform transform,Vector3 direction, float rotateSpeed);

  void MoveP(Rigidbody playerRb, Vector3 direction, float playerSpeed);
 void RotationP(Rigidbody playerRb,Transform transform,Vector3 direction, float rotateSpeed);
}

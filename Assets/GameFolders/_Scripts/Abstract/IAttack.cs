using UnityEngine;

public interface IAttack 
{
   void Attack(Transform transform,Vector3 rayDirection,float attackRange,LayerMask Layer,GameObject player,Animator anim);

}

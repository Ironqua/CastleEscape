using UnityEngine;

public class EnemyAttack :IAttack
{
  

    public void Attack(Transform transform, Vector3 rayDirection,float attackRange, LayerMask enemyLayer,GameObject character,Animator anim)
    {
         RaycastHit hit;
        if (Physics.Raycast(transform.position, rayDirection, out hit, attackRange, enemyLayer))
         {
         
            //  if(pLevel<=eLevel)
              
                
            
                anim.SetTrigger("isEnemyAttack");
                //hit.collider.gameObject.GetComponentInChildren<Animator>().SetTrigger("isPlayerDead");

                Vector3 pos=hit.collider.gameObject.GetComponent<Transform>().position;
                hit.collider.gameObject.GetComponent<PlayerController>().movementSpeed=0f;
              
                EffectManager.Instance.DeadEffect(pos);
              
               hit.collider.gameObject.SetActive(false);
              

            
         }
    }

   
}
